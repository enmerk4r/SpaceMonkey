# SpaceMonkey
A sample Rhino plugin to showcase MVVM, MaterialDesign and calling into a REST API. For the purposes of this exercise we're writing a tool that calls into the N2YO API in order to get current coordinates and metadata for satellites in Earth's orbit, which we can then bake to Rhino. This project very purposely **does not use IoC**, which would normally be another vital component of scalable modern applications. This is because IoC is a whole other animal to tackle and we're just trying to focus on the WPF side of things here.

![](https://github.com/enmerk4r/SpaceMonkey/blob/main/Assets/FrontPage.PNG)

## Requirements
- Visual Studio 2019 or later (Community is fine)
- Rhino 6
- .NET framework 4.8 or higher

## Installation
1. After you clone the repo, go to [N2YO](https://www.n2yo.com/login/register/), create a new free account and generate an API key. 
2. In Visual Studio create a file named "secrets.json" at the root of the SpaceMonkey.Rhinoceros project (VS will complain about a missing file there, so you'll see it)
3. Inside that file paste your API key in the following format:
```
{
    "api_key": "PUT_YOUR_API_KEY_HERE"
}
```
4. Makse sure that SpaceMonkey.Rhinoceros is set as the startup project. 
5. Make sure that if you right-click on the project, then go to Properties > Debug, the "Start action" field is set to Start External Program and is pointing to `C:\Program Files\Rhino 6\System\Rhino.exe` (or wherever your Rhino 6 is installed)
6. Hit "Run"
7. [ATTN: DO THIS ONLY ONCE] After you build the project and start Rhino for the first time, go to the `bin` folder of SpaceMonkey.Rhinoceros (`\SpaceMonkey\SpaceMonkey.Rhinoceros\bin`), find a file called `SpaceMonkey.Rhinoceros.rhp` and drag it into the Rhino canvas. That will register the plugin to your instance of Rhino.
8. Run the `SpaceMonkey` command in Rhino's command line

![](https://github.com/enmerk4r/SpaceMonkey/blob/main/Assets/SpaceMonkey_1.gif)
