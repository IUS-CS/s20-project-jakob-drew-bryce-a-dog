# Sky Assault

Sky Assault is an endless survival Virtual Reality game. When the game is loaded up you start in an environment where you are faced by a pedestal holding a bow. Your first objective is to teleport to the bow stand and pick up the bow. After the bow is picked up, you are able to shoot a target in front of you. Shooting this target will start the spawning of various enemies around you, as well as a timer that counts up. Use the bow that you picked up to neutralize the enemies in the game. Survive as long as you can!

## Prerequisites

* Unity Hub `2.2.2`
* Unity `2019.2.19f1`
* Visual Studio 2017 or newer with Unity C# tools
* SteamVR-Compatible Virtual Reality Headset (Oculus Rift or Quest via Oculus Link, HTC Vive, Valve Index, Windows Mixed Reality HMDs, etc.)
* SteamVR 1.10 or newer and Steam
* If using an Oculus HMD, in the Oculus app go to Settings -> General and make sure Unknown Sources is enabled (so that SteamVR runs as an Oculus app)
* If you do not have a VR headset, you can still play the game in testing mode using a basic ray-casting gun and FPS controls

### Minimum System Hardware Requirements

* OS: Windows 7 or 10 (recommended)
* GPU: Nvidia GeForce GTX 970 or AMD Radeon R9 290 equivalent
* CPU: Intel i5-4590 or AMD FX 8350 equivalent
* RAM: 4 GB or more
* Video Output: HDMI 1.4, DisplayPort 1.2 or newer (depending on VR HMD)

## Controls

### VR Controls

* Teleport: Point left or right controller in the direction you want to teleport, and hold *up* on the thumbstick. If using Valve Index Knuckles controllers, you can also press down on the touchpad. You will see a dotted line in an arc indicating where your teleport destination will be. Release the thumbstick or touchpad to complete the teleport.
* Snap-turn: Move the thumbstick on one of your controllers left or right to *snap-turn* your character 45 degrees in either direction. This is useful when moving around quickly so you don't have to physically turn around, possibly causing the VR headset's tether to get tangled.
* Bow pickup: When close to the bow stand, reach out with your left or right hand (whichever is your non-dominant hand) until you see a yellow highlight surrounding the bow, and press the *middle finger* button (on Oculus or Vive controllers) or simply *grab* (on Valve Index controllers) to pick it up. 
* Shoot arrow: Once the bow is in your non-dominant hand, an arrow will spawn in the opposite hand. Move it close to the bow string until you see it lining up, and press and hold the *index finger trigger* to nock the arrow. Pull back the bow string while still holding the trigger button, aim your shot, and release the trigger to shoot. Note: on Valve Index controllers you will also need to hold your thumb lightly on the trackpad while holding the trigger button to complete this action.

You can still teleport and snap-turn while holding the bow after you fire your first shot.

### FPS controls (for debug)

Movement: `W A S D` keys
Aim: Using the mouse
Shoot: Left click

Note: you can shoot the blue pedestal holding the bow to simulate picking up the bow in debug mode. The shot has a force-additive property to simulate the arrow's physics on enemies which need to be knocked off the platform to be defeated.

## Getting Started

To get started with running the application on your own machine, refer to the following steps

* Clone the [GitHub Repository](https://github.com/IUS-CS/s20-project-jakob-drew-bryce-a-dog)
* Install [Unity Hub 2.2.2](https://unity3d.com/get-unity/download)
* Install the [Unity 2019.2.19f1](https://unity3d.com/get-unity/download/archive) into Unity Hub
* Install [Visual Studio 2017 or newer](https://visualstudio.microsoft.com/downloads/). Make sure that Unity C# tools are installed with your VS in Visual Studio Installer
* Open the project in Unity and ensure that it runs correctly 

## Contributing

Branches should be checked out against the `master` branch and worked on individually. Once ready and everything is ensured to be working, create a pull request to merge your branch into 'master'. Give a proper description of changes that were made. Review from an authorized developer is required before the merge can take place.

## Authors and Acknowledgement

* Bryce Winnecke
* Drew Yellina
* Jakob Markland

## License

[MIT](https://choosealicense.com/licenses/mit/)
