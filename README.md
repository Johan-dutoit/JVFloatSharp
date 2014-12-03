JVFloatSharp
============

This is a Xamarin.Android port of [Jared Verdi's JVFloatLabeledTextField](https://github.com/jverdi/JVFloatLabeledTextField), that changes placeholders/hints into floating labels when the field is populated with text.

Credits for the concept to Matt D. Smith, and his original design:

![Matt D. Smith's Design](http://dribbble.s3.amazonaws.com/users/6410/screenshots/1254439/form-animation-_gif_.gif)

http://dribbble.com/shots/1254439--GIF-Mobile-Form-Interaction?list=users

Usage
=====

```xml
    <JVFloatSharp.FloatLabeledEditText
        android:layout_width="match_parent"
        android:layout_height="wrap_content">

        <EditText
            android:layout_width="match_parent"
            android:layout_height="wrap_content"
            android:hint="This is the hint" />
    </JVFloatSharp.FloatLabeledEditText>

    <!-- add some padding -->
    <JVFloatSharp.FloatLabeledEditText
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        float:fletPadding="10dp">

        <EditText
            android:layout_width="match_parent"
            android:layout_height="wrap_content"
            android:hint="Username" />
    </JVFloatSharp.FloatLabeledEditText>

    <!-- password input -->
    <JVFloatSharp.FloatLabeledEditText
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        float:fletPaddingBottom="10dp">

        <EditText
            android:layout_width="match_parent"
            android:layout_height="wrap_content"
            android:hint="Password"
            android:inputType="textPassword" />
    </JVFloatSharp.FloatLabeledEditText>

    <!-- change color of hint text-->
    <JVFloatSharp.FloatLabeledEditText
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        float:fletPaddingBottom="10dp"
        float:fletTextAppearance="@style/floatlabelededittext">

        <EditText
            android:layout_width="match_parent"
            android:layout_height="wrap_content"
            android:hint="Styled Hint"
            android:inputType="textPassword" />
    </JVFloatSharp.FloatLabeledEditText>
```
