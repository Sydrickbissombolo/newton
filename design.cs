/* Classes & Inheritance:

Base Activity Class (abstract)
Behaviors:
StartActivity(activityName: string, description: string, duration: int)
EndActivity(activityName: string, duration: int)
ShowSpinner()
Countdown(duration: int)
Attributes:
activityName: string
description: string
duration: int
Breathing Activity Class (inherits from Base Activity Class)
Behaviors:
BreathingActivity(duration: int)
Reflection Activity Class (inherits from Base Activity Class)
Behaviors:
ReflectionActivity(duration: int)
Listing Activity Class (inherits from Base Activity Class)
Behaviors:
ListingActivity(duration: int)
Constructors:

Base Activity Class:
Constructor to initialize activityName, description, and duration.
Breathing Activity Class:
Constructor to initialize activityName, description, and duration. Calls the base class constructor.
Reflection Activity Class:
Constructor to initialize activityName, description, and duration. Calls the base class constructor.
Listing Activity Class:
Constructor to initialize activityName, description, and duration. Calls the base class constructor.
Interaction:
The Program class acts as the entry point for the application. It contains the Main() method and handles user interactions, such as displaying the menu and invoking the appropriate activity methods based on the user's choice. The Program class will create instances of the derived activity classes (Breathing Activity, Reflection Activity, and Listing Activity) and call their respective methods.

The derived activity classes inherit the behaviors and attributes from the base activity class. They provide specific implementations for each activity, including prompts, input collection, and displaying the number of items entered.

The base activity class provides common behaviors and attributes shared by all activities. The StartActivity() method displays the starting message, EndActivity() displays the ending message, ShowSpinner() implements the spinner animation, and Countdown() performs the countdown functionality.