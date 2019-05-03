# RedDirt

> A narrative game about retracing a path into memories.

This narrative game uses a magnet-based controller. You use it to retrace symbols and navigate a story through space and time.

Red Dirt uses an earlier version of the tool [Sensing Gestures](https://github.com/enricllagostera/SensingGestures). I'm sharing its code as an example of a more complex use of gesture-based interactions. In this case, the gestures use the magnetic fields sensors of an Android phone. It was made using Unity 2018.3.12+.

You can find a [discussion and account of Red Dirt's design process here](https://github.com/enricllagostera/RedDirt/wiki/Discussion). 

## Usage

You can download the project and open it in the Unity editor. To run it, you'll need either a wifi to connect the Android phone for OSC-based input (see [more info on how and why to do it here](https://github.com/enricllagostera/SensingGestures/wiki/OSC-based-prototyping-and-native-sensors)) or you can build the app for the phone using Unity's build options and play the game there.

When running the game, make sure to first go in the **options** menu to record the basic four gestures you'll use throughout the game.

## Links

+ The magnet-based gestures used in this game were developed together with the [Sensing Gestures](https://github.com/enricllagostera/SensingGestures) tool. Check its page for more info and a more reusable version of that system.
+ aseprite-importer
+ DollarOne
+ PDollar
+ OscJack
+ UnityAndroidSensors
+ Ink

## Licensing

Audio, visuals and narrative scripts are all licensed under an Attribution-NonCommercial 4.0 International [(CC BY-NC 4.0)](https://creativecommons.org/licenses/by-nc/4.0/) license. Code specific to this project is under the  LGPL-3.0 (GNU Lesser General Public License v3.0). As for libraries used, each has its own license.
