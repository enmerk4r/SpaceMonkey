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

## Resources
![](https://github.com/enmerk4r/SpaceMonkey/blob/main/Assets/SpaceMonkey_1.gif)

### Livestream
The original livestream where this project and its underlying concepts are discussed [can be found here](https://www.youtube.com/watch?v=s7WC-3DGpoI&t=1589s&ab_channel=EngineeringArchiTECHure)

### Satellite Tracking API
The satellite tracking API is provided by [N2YO](https://www.n2yo.com/)
Their REST API documentation can be found [here](https://www.n2yo.com/api/)

### McNeel's Rhino plugin sample
We all know that McNeel are awesome, which is why they provide a [wealth of code samples](https://github.com/mcneel/rhino-developer-samples) for Rhino and Grasshopper developers on their GitHub page. For instance, you can find a very barebones implementation of a dockable Rhino plugin that uses WPF [via this link](https://github.com/mcneel/rhino-developer-samples/tree/7/rhinocommon/cs/SampleCsWpf). SpaceMonkey also uses that sample.

### Deep dive into MVVM and IoC
If you want to learn more about MVVM and start learning about IoC, then check out [this great YouTube playlist](https://www.youtube.com/playlist?list=PLrW43fNmjaQVYF4zgsD0oL9Iv6u23PI6M) by [AngelSix](https://www.youtube.com/c/AngelSix). This is an in-depth, step-by-step walk through the process of building an MVVM application that follows the IoC pattern. SpaceMonkey uses some of the MVVM-related base classes from these tutorials.

### WPF Material Design
The project's website can be found [here](http://materialdesigninxaml.net/)

WPF Material Design library has been built by [James Willock](https://github.com/ButchersBoy)

And here's the project's [GitHub page](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit) with links to documentation and Wikis

## Troubleshooting
### Fody throws build errors
If you see an error saying `Fody is only supported on MSBuild 16 and above`, then you're running an older version of Visual Studio: you need VS 2019 or older. That's no big deal, because Visual Studio community is free. If, however, you really really really don't want to install new VS, you can simply downgrade Fody to v3.x.x.

### Rhino 6 says the plugin is not compatible
You have an old Service Pack. Just upgrade your Rhino.

### Visual Studio doesn't build because of a missing "secrets.json" file
Read the installation instructions above. That file has to be created by you and contain your free API key for N2YO
