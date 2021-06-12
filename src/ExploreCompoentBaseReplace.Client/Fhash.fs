module Fhash

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Components
open Bolero
open Bolero.Render
open Microsoft.AspNetCore.Components.Rendering

type HashApp() =

  let mutable _renderHandle = Unchecked.defaultof<Microsoft.AspNetCore.Components.RenderHandle>

  let matchCache = Bolero.Render.makeMatchCache()

  let renderDelegate(builder: Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder) =
        let mutable max = Math.Min(4, 5)
        let mutable xseq = 1
        let add1 () =  
          xseq <- (xseq + 1)
          xseq

        for i = 0 to (max - 1) do
            builder.OpenElement(add1 (), "span" )
            builder.AddAttribute(add1 (), "style", "color:#f49813;font-size:30px")
            builder.AddContent(add1 (), "★")
            builder.CloseElement()
        ()

  interface Microsoft.AspNetCore.Components.IComponent with
    member this.Attach renderHandle = 
        _renderHandle <- renderHandle

    member this.SetParametersAsync parameters = 
        //_renderHandle.Render(renderDelegate)
        Task.CompletedTask

//////////////////////////////////////////////////////////////////////////////////////////////
type Delegate2 = delegate of RenderTreeBuilder -> RenderFragment

type AppComponent() as foo =

  let myNode = Bolero.Html.div [] [Bolero.Html.text "Hello from AppComponent."]
  let matchCache = Render.makeMatchCache()
  let builder = new RenderTreeBuilder()


  //do RenderNode foo builder matchCache myNode

  let mutable _renderHandle = Unchecked.defaultof<Microsoft.AspNetCore.Components.RenderHandle>
  let mutable _renderFragment = Unchecked.defaultof<Microsoft.AspNetCore.Components.RenderFragment>
  // _renderFragment <- RenderNode foo builder matchCache myNode
  let renderDelegate (bdr:RenderTreeBuilder) = 
    bdr.OpenElement(1, "span")
    bdr.AddAttribute(60,
      "style", "color:#f49813;font-size:30px")
    bdr.AddContent(30, "★")
    bdr.CloseElement()

  let InvokeDelegate2 (dlg: Delegate2) builder =
    dlg.Invoke(builder)
    
  do foo.RenderDelegate(builder)

  //do _renderFragment <- (InvokeDelegate2)

  interface Microsoft.AspNetCore.Components.IComponent with
    member this.Attach renderHandle = 
      printfn "Attach:_renderHandle.IsInitialized %A" _renderHandle.IsInitialized
      _renderHandle <- renderHandle
      printfn "Attach:IComponent.Attach fired"
      printfn "Attach:_renderHandle.IsInitialized %A" _renderHandle.IsInitialized
      
    member this.SetParametersAsync parameters = 
      printfn "SetParametersAsync:IComponent.SetParametersAsync fired"
      printfn "SetParametersAsync1:_renderHandle.IsInitialized %A" _renderHandle.IsInitialized
      _renderHandle.Render(_renderFragment)
      printfn "SetParametersAsync2:_renderHandle.IsInitialized %A" _renderHandle.IsInitialized
      printfn "SetParametersAsync:_renderHandle.ToString %A" _renderHandle.ToString
      printfn "SetParametersAsync:builder.GetFrames %A" builder.GetFrames
      Task.CompletedTask
  member private this.RenderDelegate(builder: RenderTreeBuilder)  =
    let mutable max = Math.Min(4, 5)
    let mutable xseq = 1
    let add1 () =  
      xseq <- (xseq + 1)
      xseq

    for i = 0 to (max - 1) do
        builder.OpenElement(add1 (), "span" )
        builder.AddAttribute(add1 (), "style", "color:#f49813;font-size:30px")
        builder.AddContent(add1 (), "★")
        builder.CloseElement()
    

open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Rendering

//type Rating() =
//    let mutable _renderHandle = Unchecked.defaultof<RenderHandle>
//    member val Value: int = Unchecked.defaultof<int> with get, set


//    member this.Attach(renderHandle: RenderHandle) = _renderHandle <- renderHandle


//    member this.SetParametersAsync(parameters: ParameterView): Task =
//        for entry in parameters do
//            ``Not supported: switch (entry.Name)
//                {
//                    case nameof(Value):
//                        Value = (int)entry.Value;
//                        break;
//                } Line:16, Col:0``

//        _renderHandle.Render(this.RenderDelegate)
//        Task.CompletedTask


//    member private this.RenderDelegate(builder: RenderTreeBuilder) =
//        let mutable max = Math.Min(Value, 5)
//        let mutable seq = 1
//        for i = 0 to (max - 1) do
//            builder.OpenElement(seq <- seq + 1, "span")
//            builder.AddAttribute(seq <- seq + 1, "style", "color:#f49813;font-size:30px")
//            builder.AddContent(seq <- seq + 1, "★")
//            builder.CloseElement()

//    interface IComponent with

//        member this.Todo() = ()


//type MyAddingService() =

//    interface IAddingService with
//        member this.Add x y =
//            x + y

//    interface System.IDisposable with
//        member this.Dispose() =
//            printfn "disposed"