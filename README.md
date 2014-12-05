JVFloatSharp
============
This is a Xamarin.Android port of [Jared Verdi's JVFloatLabeledTextField](https://github.com/jverdi/JVFloatLabeledTextField), which was directly ported from the Android version by Henrik Sandström [@heinrisch](https://twitter.com/Heinrisch)

Credits for the concept to Matt D. Smith ([@mds](http://www.twitter.com/mds)).


![Android Version](http://i.imgur.com/ucRd1jm.gif)

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

Styled By
=========
* Marcus Gellemark [Dribbble](http://dribbble.com/Gellermark)
