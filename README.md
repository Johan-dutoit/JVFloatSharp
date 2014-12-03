Float Labeled EditText
==============

Simple implementation of a Float Labeled EditText: An Android ViewGroup which uses a child EditText and puts the hint on top of the EditText when it is populated with text.

iOS implementation by [@jverdi](http://www.twitter.com/jverdi): [JVFloatLabeledTextField](https://github.com/jverdi/JVFloatLabeledTextField) 

Credits for the concept to Matt D. Smith ([@mds](http://www.twitter.com/mds)).

![Android Version](http://i.imgur.com/ucRd1jm.gif)

http://dribbble.com/shots/1254439--GIF-Mobile-Form-Interaction?list=users

Usage
=====

and then insert the view in XML:

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
