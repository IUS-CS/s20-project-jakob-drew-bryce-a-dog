# Design Patterns

This document serves to illustrate the software development design patterns used in the making of our game.

## Singletons

The most basic design pattern we use in our project is the Singleton type class for our scripts. In Unity every script inherits from Monobehavior by default, which gives the script certain Unity-specific methods like Update() (an infinite loop executing once per frame), Start() (executing once at scene load), OnEnable() (executing when that component becomes active in the heirarchy), etc. However, Monobehaviors need to be processed independently of other Monobehaviors of the same class type, so for instance a Monobehavior BoxEnemy's coroutine would run parallel to another BoxEnemy's coroutine and not interfere with one another. 

The benefit for us is for our high-level SystemController classes like GameFlowController. We know for a fact that only one of those needs to be in the scene at any given time, because if there were multiple it could cause some very nasty bugs that would be hard to track down. We can lock it to one instance easily by making it inherit from Singleton, while also retaining the Monobehavior-specific Unity methods like Update().

Another benefit is that it speeds up our time writing scripts for new GameObjects. If we had GameFlowController inherit from Monobehavior, then a BoxEnemy would have to reference it like this:

`GameFlowController flowController;

new private void Awake()
{
	flowController = GameObject.FindWithTag("GameFlowController").GetComponent<GameFlowController>();
}

void ExampleMethod()
{
	gameFlowController.DoTheThing();
}`

However, using Singletons, we can simply:

`void ExampleMethod()
{
	GameFlowController.Instance?.DoTheThing();
}`

## Factories

Although we didn't design it ourselves, we are using the SteamVR plugin for Unity as a sort of Factory layer for Virtual Reality controller inputs. This lets us use simple code which will work on a wide range of Virtual Reality headsets and controllers, including the Oculus Rift and Quest, HTC Vive, Valve Index, and Windows Mixed Reality headsets. 

As an example, the default way to "grab" objects with VR controllers differs for each controller type. On Oculus and HTC controllers pressing the "middle finger" button acts as a grab input, but on the new Valve Index which features full-range finger tracking, the user actually grabs the controller with at least three fingers or a certain amount of pressure on the grip pressure pad to initiate a grab. The SteamVR plugin lets us not have to worry about these differences, and if we want to call some event (like attaching it to the hand) on a hand grab, we can simply:

`protected virtual void HandHoverUpdate( Hand hand )
{
	GrabTypes startingGrabType = hand.GetGrabStarting();

	if (startingGrabType != GrabTypes.None)
	{
		hand.AttachObject( gameObject, startingGrabType, attachmentFlags, attachmentOffset);
	}
}`

In this way we can easily make the game work uniformly with any SteamVR-compatible headset and controllers, and this also lets users rebind the default controller bindings to suit their preferences within the SteamVR app, with no need for us to modify the game.