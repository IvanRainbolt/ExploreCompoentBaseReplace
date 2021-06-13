# ExploreComponentBaseReplace

I have been banging my head on this all week. 
I am asking for help. 
I am willing to pay consulting fees for someone to help me answer questions up to full on dev. It is just on very piecemeal basis. 

Here is the repo:
https://github.com/IvanRainbolt/ExploreCompoentBaseReplace

Changing between the C# base components is in startup.fs
Change the commented lines. 

The idea is to not use inherit from (Microsoft.AspNetCore.Components) ComponentBase (reasons are not really relevant for this issue, this is just a very first step in my overall plan) but instead implement the IComponent interface directly. 

I have gotten a lot of understanding and help from the following:

https://github.com/ShaunCurtis/Rebuilding-The-Blazor-Component
https://www.codeproject.com/Articles/5277618/A-Dive-into-Blazor-Components

https://fsharpforfunandprofit.com/posts/interfaces/

https://chrissainty.com/building-a-custom-router-for-blazor/

https://fsharpforfunandprofit.com/posts/porting-to-csharp-intro/

https://dev.to/madhust/blazor-in-depth-create-blazor-component-without-lifecycle-methods-2786


lot of MS docs:
https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.icomponent?view=aspnetcore-5.0

https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.componentbase?view=aspnetcore-5.0

https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.rendering.rendertreebuilder?view=aspnetcore-5.0

and MS github: 
https://github.com/dotnet/aspnetcore/blob/main/src/Components/Components/src/IComponent.cs

https://github.com/dotnet/aspnetcore/blob/main/src/Components/Components/src/Routing/Router.cs

https://github.com/dotnet/aspnetcore/blob/main/src/Components/Components/src/ComponentBase.cs


lots of reviewing .fs files in 
https://github.com/fsbolero/Bolero/tree/master/src/Bolero
especially Components.fs and Render.fs

trying to understand 
https://github.com/fsbolero/Bolero/issues/202
https://github.com/dotnet/aspnetcore/issues/29260

and ref my own question of 
https://github.com/fsbolero/Bolero/issues/150

The C# working component in my repo is based on 
https://www.codeproject.com/Articles/5277618/A-Dive-into-Blazor-Components

https://dev.to/madhust/blazor-in-depth-create-blazor-component-without-lifecycle-methods-2786

#### So my ask for help would be to do a direct port of the C# ClassLibrary1.Rating2 to an F# version that actually works the same way.

##### Second, would there be a better F# version? If so, an example.

This is WASM Blazor but not really and Bolero, but not really (as was told to me that Bolero is really elmish) so I am using and referencing Bolero code but really it's a matter of running ui in f# on WASM. A big part of the Bolero basis is just because it is the only F# on WASM really out there.
  
My hangup is that first, I still do not understand the steps happening with the RenderTree (like how it actually renders), and the RenderFragment and those sort of things. Still working on that learning.  
The crucial hangup seems to be the usage of delegates. From studying ComponentBase and routers and such, the key seems to be  `_renderHandle.Render(_renderFragment)`  
a type Microsoft.AspNetCore.Components.RenderHandle instance that has the render method. 
The .Render takes a Microsoft.AspNetCore.Components.RenderFragment
which is defined as a delegate. That is where I go off the rails.


https://dev.to/madhust/blazor-in-depth-create-blazor-component-without-lifecycle-methods-2786

So my ask for help would be to do a direct port of the C# ClassLibrary1.Rating2 to an F# version that actually works the same way. 

Second, would there be a better F# version? If so, an example. 

This is WASM Blazor but not really and Bolero, but not really (as was told to me that Bolero is really elmish) so I am using and referencing Bolero code but really it's a matter of running ui in f# on WASM. A big part of that is just because it is the only F# on WASM really out there.
  
My hangup is that first, I still do not understand the steps happening with the RenderTree (like how it actually renders), and the RenderFragment and those sort of things. Still working on that learning.  
The crucial hangup seems to be the usage of delegates. From studying ComponentBase and routers and such, the key seems to be " _renderHandle.Render(_renderFragment) "  
a type Microsoft.AspNetCore.Components.RenderHandle instance that has the render method. 
The .Render takes a Microsoft.AspNetCore.Components.RenderFragment
which is defined as a delegate. That is where I go off the rails.

Changing between the C# base components is in startup.fs
Change the commented lines. 
