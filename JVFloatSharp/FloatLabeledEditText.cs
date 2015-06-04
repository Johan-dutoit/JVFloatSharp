//  The MIT License (MIT)
//
//  Copyright (c) 2013 Greg Shackles
//  Original implementation by Jared Verdi
//	https://github.com/jverdi/JVFloatLabeledTextField
//  Original Concept by Matt D. Smith
//  http://dribbble.com/shots/1254439--GIF-Mobile-Form-Interaction?list=users
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy of
//  this software and associated documentation files (the "Software"), to deal in
//  the Software without restriction, including without limitation the rights to
//  use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
//  the Software, and to permit persons to whom the Software is furnished to do so,
//  subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
//  FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//  COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
//  IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
//  CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using Android.Animation;
using Android.Content;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace JVFloatSharp
{
    [Register("jvfloatsharp.FloatLabeledEditText")]
    public class FloatLabeledEditText : FrameLayout
    {
        private const float DefaultPaddingLeft = 2;

        private TextView _hintTextView;
        private EditText _editText;

        private bool ShowHint { get; set; }

        public EditText EditText
        {
            get { return _editText; }
            private set
            {
                _editText = value;
                _editText.AfterTextChanged += EditTextAfterTextChanged;
                _editText.FocusChange += EditTextFocusChange;
                _editText.Visibility = ViewStates.Visible;

                _hintTextView.Text = _editText.Hint;
                if (!string.IsNullOrEmpty(_editText.Text))
                {
                    _hintTextView.Visibility = ViewStates.Visible;
                }
            }
        }

        public string Hint
        {
            get { return _hintTextView.Hint; }
            set
            {
                _editText.Hint = value;
                _hintTextView.Hint = value;
            }
        }

        public FloatLabeledEditText(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer) { }

        public FloatLabeledEditText(Context context)
            : this(context, null) { }

        public FloatLabeledEditText(Context context, IAttributeSet attrs)
            : this(context, attrs, 0) { }

        public FloatLabeledEditText(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            if (attrs != null)
                SetAttributes(attrs);
        }

        private void SetAttributes(IAttributeSet attrs)
        {
            _hintTextView = new TextView(Context);

            var typedArray = Context.ObtainStyledAttributes(attrs, Resource.Styleable.FloatLabeledEditText);

            var padding = typedArray.GetDimensionPixelSize(Resource.Styleable.FloatLabeledEditText_fletPadding, 0);
            var defaultPadding = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, DefaultPaddingLeft, Resources.DisplayMetrics);
            var paddingLeft = typedArray.GetDimensionPixelSize(Resource.Styleable.FloatLabeledEditText_fletPaddingLeft, defaultPadding);
            var paddingTop = typedArray.GetDimensionPixelSize(Resource.Styleable.FloatLabeledEditText_fletPaddingTop, 0);
            var paddingRight = typedArray.GetDimensionPixelSize(Resource.Styleable.FloatLabeledEditText_fletPaddingRight, 0);
            var paddingBottom = typedArray.GetDimensionPixelSize(Resource.Styleable.FloatLabeledEditText_fletPaddingBottom, 0);

            if (padding != 0)
                _hintTextView.SetPadding(padding, padding, padding, padding);
            else
                _hintTextView.SetPadding(paddingLeft, paddingTop, paddingRight, paddingBottom);

            _hintTextView.SetTextAppearance(Context, typedArray.GetResourceId(Resource.Styleable.FloatLabeledEditText_fletTextAppearance, Android.Resource.Style.TextAppearanceSmall));

            //Start hidden
            _hintTextView.Visibility = ViewStates.Invisible;

            AddView(_hintTextView, ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);

            typedArray.Recycle();
        }

        public override void AddView(View child, int index, ViewGroup.LayoutParams layoutParams)
        {
            var text = child as EditText;
            if (text != null)
            {
                if (_editText != null)
                    throw new IllegalArgumentException("Can only have one Edittext subview");

                var lp = new LayoutParams(layoutParams) {
                    Gravity = GravityFlags.Bottom,
                    TopMargin =
                        (int)
                            (_hintTextView.TextSize + _hintTextView.PaddingBottom +
                             _hintTextView.PaddingTop)
                };
                layoutParams = lp;

                EditText = text;
            }

            base.AddView(child, index, layoutParams);
        }

        private void EditTextFocusChange(object sender, FocusChangeEventArgs e)
        {
            OnFocusChanged(e.HasFocus);
        }

        private void EditTextAfterTextChanged(object sender, AfterTextChangedEventArgs e)
        {
            ShowHint = !TextUtils.IsEmpty(e.Editable);
            SetShowHint();
        }

        private void OnFocusChanged(bool gotFocus)
        {
            if (gotFocus && _hintTextView.Visibility == ViewStates.Visible)
            {
                ObjectAnimator.OfFloat(_hintTextView, "alpha", 0.33f, 1f).Start();
            }
            else if (_hintTextView.Visibility == ViewStates.Visible)
            {
                ObjectAnimator.OfFloat(_hintTextView, "alpha", 1f, 0.33f).Start();
            }
        }

        private void SetShowHint()
        {
            AnimatorSet animation = null;
            if ((_hintTextView.Visibility == ViewStates.Visible) && !ShowHint)
            {
                animation = new AnimatorSet();
                var move = ObjectAnimator.OfFloat(_hintTextView, "translationY", 0, _hintTextView.Height / 8f);
                var fade = ObjectAnimator.OfFloat(_hintTextView, "alpha", 1, 0);
                animation.PlayTogether(move, fade);
            }
            else if ((_hintTextView.Visibility != ViewStates.Visible) && ShowHint)
            {
                animation = new AnimatorSet();
                var move = ObjectAnimator.OfFloat(_hintTextView, "translationY", _hintTextView.Height / 8f, 0);
                var fade = ObjectAnimator.OfFloat(_hintTextView, "alpha", 0,
                    _editText.IsFocused ? 1 : 0.33f);
                animation.PlayTogether(move, fade);
            }

            if (animation == null) return;

            animation.AnimationStart += AnimationAnimationStart;
            animation.AnimationEnd += AnimationAnimationEnd;
            animation.Start();
        }

        private void AnimationAnimationStart(object sender, EventArgs e)
        {
            OnAnimationStart();
            _hintTextView.Visibility = ViewStates.Visible;
        }

        private void AnimationAnimationEnd(object sender, EventArgs e)
        {
            OnAnimationEnd();
            _hintTextView.Visibility = ShowHint ? ViewStates.Visible : ViewStates.Invisible;
        }
    }
}
