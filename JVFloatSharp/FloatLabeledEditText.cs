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

using Android.Animation;
using Android.Content;
using Android.Content.Res;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System;

namespace JVFloatSharp
{
    public class FloatLabeledEditText : FrameLayout
    {
        private static float DEFAULT_PADDING_LEFT = 2;

        private TextView mHintTextView;
        private EditText mEditText;

        private Context mContext;

        private bool ShowHint { get; set; }

        public FloatLabeledEditText(Context context)
            : base(context)
        {
            mContext = context;
        }

        public FloatLabeledEditText(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            mContext = context;
            SetAttributes(attrs);
        }

        public FloatLabeledEditText(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            mContext = context;
            SetAttributes(attrs);
        }

        private void SetAttributes(IAttributeSet attrs)
        {
            mHintTextView = new TextView(mContext);

            var typedArray = mContext.ObtainStyledAttributes(attrs, Resource.Styleable.FloatLabeledEditText);

            int padding = typedArray.GetDimensionPixelSize(Resource.Styleable.FloatLabeledEditText_fletPadding, 0);
            int defaultPadding = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, DEFAULT_PADDING_LEFT, Resources.DisplayMetrics);
            int paddingLeft = typedArray.GetDimensionPixelSize(Resource.Styleable.FloatLabeledEditText_fletPaddingLeft, defaultPadding);
            int paddingTop = typedArray.GetDimensionPixelSize(Resource.Styleable.FloatLabeledEditText_fletPaddingTop, 0);
            int paddingRight = typedArray.GetDimensionPixelSize(Resource.Styleable.FloatLabeledEditText_fletPaddingRight, 0);
            int paddingBottom = typedArray.GetDimensionPixelSize(Resource.Styleable.FloatLabeledEditText_fletPaddingBottom, 0);

            if (padding != 0)
            {
                mHintTextView.SetPadding(padding, padding, padding, padding);
            }
            else
            {
                mHintTextView.SetPadding(paddingLeft, paddingTop, paddingRight, paddingBottom);
            }

            mHintTextView.SetTextAppearance(mContext, typedArray.GetResourceId(Resource.Styleable.FloatLabeledEditText_fletTextAppearance, global::Android.Resource.Style.TextAppearanceSmall));

            //Start hidden
            mHintTextView.Visibility = Android.Views.ViewStates.Invisible;

            AddView(mHintTextView, LayoutParams.WrapContent, LayoutParams.WrapContent);

            typedArray.Recycle();
        }

        public override void AddView(View child, int index, ViewGroup.LayoutParams layoutParams)
        {
            if (child is EditText)
            {
                if (mEditText != null)
                {
                    throw new IllegalArgumentException("Can only have one Edittext subview");
                }

                LayoutParams lp = new LayoutParams(layoutParams);
                lp.Gravity = GravityFlags.Bottom;
                lp.TopMargin = (int)(mHintTextView.TextSize + mHintTextView.PaddingBottom + mHintTextView.PaddingTop);
                layoutParams = lp;

                SetEditText((EditText)child);
            }

            base.AddView(child, index, layoutParams);
        }

        private void SetEditText(EditText editText)
        {
            mEditText = editText;
            mEditText.AfterTextChanged += mEditTextAfterTextChanged;
            mEditText.BeforeTextChanged += mEditTextBeforeTextChanged;
            mEditText.TextChanged += mEditTextTextChanged;
            mEditText.FocusChange += mEditText_FocusChange;
            mEditText.Visibility = ViewStates.Visible;

            mHintTextView.Text = mEditText.Hint;
            if (!TextUtils.IsEmpty(mEditText.Text))
            {
                mHintTextView.Visibility = ViewStates.Visible;
            }
        }

        private void mEditText_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            OnFocusChanged(e.HasFocus);
        }

        private void mEditTextTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void mEditTextBeforeTextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void mEditTextAfterTextChanged(object sender, AfterTextChangedEventArgs e)
        {
            ShowHint = !TextUtils.IsEmpty(e.Editable);
            SetShowHint();
        }

        private void OnFocusChanged(bool gotFocus)
        {
            if (gotFocus && mHintTextView.Visibility == ViewStates.Visible)
            {
                ObjectAnimator.OfFloat(mHintTextView, "alpha", 0.33f, 1f).Start();
            }
            else if (mHintTextView.Visibility == ViewStates.Visible)
            {
                ObjectAnimator.OfFloat(mHintTextView, "alpha", 1f, 0.33f).Start();
            }
        }

        private void SetShowHint()
        {
            AnimatorSet animation = null;
            if ((mHintTextView.Visibility == ViewStates.Visible) && !ShowHint)
            {
                animation = new AnimatorSet();
                ObjectAnimator move = ObjectAnimator.OfFloat(mHintTextView, "translationY", 0, mHintTextView.Height / 8);
                ObjectAnimator fade = ObjectAnimator.OfFloat(mHintTextView, "alpha", 1, 0);
                animation.PlayTogether(move, fade);
            }
            else if ((mHintTextView.Visibility != ViewStates.Visible) && ShowHint)
            {
                animation = new AnimatorSet();
                ObjectAnimator move = ObjectAnimator.OfFloat(mHintTextView, "translationY", mHintTextView.Height / 8, 0);
                ObjectAnimator fade;
                if (mEditText.IsFocused)
                {
                    fade = ObjectAnimator.OfFloat(mHintTextView, "alpha", 0, 1);
                }
                else
                {
                    fade = ObjectAnimator.OfFloat(mHintTextView, "alpha", 0, 0.33f);
                }
                animation.PlayTogether(move, fade);
            }

            if (animation != null)
            {
                animation.AnimationStart += AnimationAnimationStart;
                animation.AnimationEnd += AnimationAnimationEnd;
                animation.Start();
            }
        }

        private void AnimationAnimationStart(object sender, EventArgs e)
        {
            base.OnAnimationStart();
            mHintTextView.Visibility = ViewStates.Visible;
        }

        private void AnimationAnimationEnd(object sender, EventArgs e)
        {
            base.OnAnimationEnd();

            mHintTextView.Visibility = ShowHint ? ViewStates.Visible : ViewStates.Invisible;
        }

        public EditText GetEditText()
        {
            return mEditText;
        }

        public void SetHint(string hint)
        {
            mEditText.Hint = hint;
            mHintTextView.Text = hint;
        }

        public string GetHint()
        {
            return mHintTextView.Hint;
        }
    }
}
