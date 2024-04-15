# Real-Time VR Stained Glass

An Interactive Real-Time Unity3D VR Stained Glass Viewer Using Real Window Images.

Please see the included Licence file before use.

https://github.com/Zugidor/VR-Stained-Glass/assets/72618685/40f95c76-e44d-4400-a2a0-7edf269ca7d9

https://github.com/Zugidor/VR-Stained-Glass/assets/72618685/a0abdbc0-01d2-43b0-8094-ce8ce6c27c75

https://github.com/Zugidor/VR-Stained-Glass/assets/72618685/70a52003-782d-4347-8e86-07acd4cd5de9

Please download the contents of this repository as desired, or fork the repository for further development on GitHub. This repository is made public for reference and will not be developed further than what is presented as of 15 April 2024.

## Development Procedure

See the "Towards Real-Time 3D VR Simulation of Stained Glass Windows" Chapters 3 and 4 for detailed information.

It is recommended to consult the Official Unity Documentation as cited in the thesis. For those completely unfamiliar with the engine, consider completing tutorials on the official Unity Learn website and browsing the official Unity YouTube channel.

## Notes

- Three .mp4 video files are included that demonstrate the project. panning.mp4 and mockhmd.mp4 are recorded inside Unity Editor in the MockHMD scene with slightly differently configured stained glass material and directional light sources from what is provided. gcvr.mp4 is recorded using the built-in screen recorded on an Asus ROG Phone 5 running Android 13.
- Four pre-built .apk files are included as examples. These can be installed on an Android device for testing or ignored and deleted as desired. the Google Cardboard VR App must be installed on the Android device to be tested on. These four APKs all differ slightly in appearance but should function near-identically. Installing one APK will overwrite the previous installation by "updating" the installed app, so it is necesseray to repeatedly install the APKs to see run and compare different ones.
- The most relevant scenes are "Prototype3 MockHMD" and "Prototype3 GCVR".
- The MockHMD, GCVR, GCVR No Exterior, and GCVR No Interior scenes have lightmaps baked.
- GCVR Empty and GCVR Post & Sun don't require lightmapping.
- The other scenes are old and only exist for reference. Their lightmaps are not present and need to be rebaked to observe global illumination in these scenes. They can be safely ignored and deleted if desired.
- The "Imported" folder contains copies of all assets that were added from the Unity Asset Store or other sources, as cited in Sources.txt. This folder can be safely deleted if desired as it exists only for reference.
- StainedGlassPrototype/Assets/stainedGlass/Compressed contains unused textures that are only included for reference and can be safely deleted.
- StainedGlassPrototype/Assets/stainedGlass/SG_jojo and StainedGlassPrototype/Assets/basicGlass are only used in Prototype1 and can be safely deleted if the scene is not needed.
- StainedGlassPrortype/Settings/Other contains unused settings files that can be safely deleted.

## Contact

Please see contact information on my GitHub profile.
