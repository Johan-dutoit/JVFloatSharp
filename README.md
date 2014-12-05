JVFloatSharp
============
This is a Xamarin.Android port of [Jared Verdi's JVFloatLabeledTextField](https://github.com/jverdi/JVFloatLabeledTextField), which was directly ported by Johan du Toit [@Crims0n_D](https://twitter.com/Crims0n_D) from the [Android version](https://github.com/wrapp/floatlabelededittext) by Henrik Sandström [@heinrisch](https://twitter.com/Heinrisch)

Credits for the concept to Matt D. Smith ([@mds](http://www.twitter.com/mds)).


![Android Version](http://i.imgur.com/ucRd1jm.gif)

http://dribbble.com/shots/1254439--GIF-Mobile-Form-Interaction?list=users

Usage
=====

```xml
 <?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="fill_parent"
    android:layout_height="fill_parent" >
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
      android:layout_height="wrap_content">
    <EditText
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:hint="Username" />
  </JVFloatSharp.FloatLabeledEditText>

  <!-- password input -->
  <JVFloatSharp.FloatLabeledEditText
      android:layout_width="match_parent"
      android:layout_height="wrap_content">
    <EditText
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:hint="Password"
        android:inputType="textPassword" />
  </JVFloatSharp.FloatLabeledEditText>
</LinearLayout>
```

Styled By
=========
* Marcus Gellemark [Dribbble](http://dribbble.com/Gellermark)
