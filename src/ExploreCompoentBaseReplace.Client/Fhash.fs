module Fhash

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Components
open Bolero
open Bolero.Render
open Microsoft.AspNetCore.Components.Rendering


//////////////////////////////////////////////////////////////////////////////////////////////

type AppComponent()  =


  let mutable _renderHandle = Unchecked.defaultof<Microsoft.AspNetCore.Components.RenderHandle>
  //let mutable _renderFragment = Unchecked.defaultof<Microsoft.AspNetCore.Components.RenderFragment>
  // _renderFragment <- RenderNode foo builder matchCache myNode
  //let renderDelegate (bdr:RenderTreeBuilder) = 
  //  bdr.OpenElement(1, "span")
  //  bdr.AddAttribute(60,
  //    "style", "color:#f49813;font-size:30px")
  //  bdr.AddContent(30, "★")
  //  bdr.CloseElement()

  interface Microsoft.AspNetCore.Components.IComponent with
    member this.Attach renderHandle = 
      printfn "Attach:_renderHandle.IsInitialized %A" _renderHandle.IsInitialized
      _renderHandle <- renderHandle
      printfn "Attach:IComponent.Attach fired"
      printfn "Attach:_renderHandle.IsInitialized %A" _renderHandle.IsInitialized
      
    member this.SetParametersAsync parameters = 
      printfn "SetParametersAsync:IComponent.SetParametersAsync fired"
      printfn "SetParametersAsync1:_renderHandle.IsInitialized %A" _renderHandle.IsInitialized
      //_renderHandle.Render(_renderFragment) //just can not get this right!
      printfn "SetParametersAsync2:_renderHandle.IsInitialized %A" _renderHandle.IsInitialized
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
    

