JVFloatSharp
============
This is a Xamarin.Android port of [Jared Verdi's JVFloatLabeledTextField](https://github.com/jverdi/JVFloatLabeledTextField), which was directly ported by Johan du Toit [@Crims0n_D](https://twitter.com/Crims0n_D) from the [Android version](https://github.com/wrapp/floatlabelededittext) by Henrik Sandström [@heinrisch](https://twitter.com/Heinrisch)

Credits for the concept to Matt D. Smith ([@mds](http://www.twitter.com/mds)).


![Android Version](http://i.imgur.com/ucRd1jm.gif)

http://dribbble.com/shots/1254439--GIF-Mobile-Form-Interaction?list=users

Get it on NuGet!
================

Grab the [jvfloatsharp NuGet package][nuget] using your package manager or by installing with the following command:

    Install-Package jvfloatsharp

Usage
=====

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="fill_parent"
    android:layout_height="fill_parent" >
  <jvfloatsharp.FloatLabeledEditText
         android:layout_width="match_parent"
         android:layout_height="wrap_content">
    <EditText
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:hint="This is the hint" />
  </jvfloatsharp.FloatLabeledEditText>

  <!-- add some padding -->
  <jvfloatsharp.FloatLabeledEditText
      android:layout_width="match_parent"
      android:layout_height="wrap_content">
    <EditText
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:hint="Username" />
  </jvfloatsharp.FloatLabeledEditText>

  <!-- password input -->
  <jvfloatsharp.FloatLabeledEditText
      android:layout_width="match_parent"
      android:layout_height="wrap_content">
    <EditText
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:hint="Password"
        android:inputType="textPassword" />
  </jvfloatsharp.FloatLabeledEditText>
</LinearLayout>
```

Also works with MvvmCross:

```
<?xml version="1.0" encoding="utf-8"?>
<jvfloatsharp.FloatLabeledEditText
  xmlns:android="http://schemas.android.com/apk/res/android"
  xmlns:local="http://schemas.android.com/apk/res-auto"
  android:layout_width="match_parent"
  android:layout_height="wrap_content">
  <EditText
    android:layout_width="match_parent"
    android:layout_height="wrap_content"
    android:hint="This is the hint"
    local:MvxBind="Text Hello" />
</jvfloatsharp.FloatLabeledEditText>
```

Styled By
=========
* Marcus Gellemark [Dribbble](http://dribbble.com/Gellermark)

[nuget]: https://www.nuget.org/packages/jvfloatsharp/
