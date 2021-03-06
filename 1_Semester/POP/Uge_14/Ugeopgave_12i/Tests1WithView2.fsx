open System  
open System.Windows.Forms  
open System.ComponentModel  
open System.Drawing  
open System.Drawing

// Extended the default Form to avoid display flickered
type SmoothForm() as x =
    inherit Form()
    do x.DoubleBuffered <- true

(*
let view (sz : Size) (pen : Pen) (pts : Point [] []) : (unit -> unit) =
    let win = new SmoothForm()
    win.ClientSize <- sz
*)
let view (sz : Size) (pen : Pen) : (unit -> unit) =
    let win = new SmoothForm()
    win.ClientSize <- sz

    (*
    for i in pts do
        win.Paint.Add (fun e -> e.Graphics.DrawLines (pen, i))
    *)

    // *** Animation ***
    // timer.Tick.Add (fun e -> win.Paint.Add paint; win.Invalidate(); delta <- delta + 50; printfn "%d" delta)
    // Rotate a primitive
    let rotate (theta : float) (arr : Point []) : Point [] =
        let toInt = int << round
        let rot (t : float) (p : Point) : Point =
            let (x, y) = (float p.X, float p.Y)
            let (a, b) = (150.0 + (100.0 * cos t), 150.0 + (100.0 * sin t))
            Point (toInt a, toInt b)
        Array.set arr 1 (rot (theta) (arr.[1]))
        arr

    (*
    let size = Size (183, 230)
    let black = new Pen (Color.FromArgb (0, 0, 0))
    let red = new Pen (Color.FromArgb (255, 0, 0))
    let green = new Pen (Color.FromArgb (0, 255, 0))
    let hourHand   = [|Point(93,95); Point(93,20)|]
    let minuteHand = [|Point(93,95); Point(93,20)|]
    let secondHand = [|Point(93,95); Point(93,20)|]
    let lines = [|hourHand; minuteHand; secondHand|]
    *)

    (*
    // Drawing the lines with index and drawing the circle, and invalidating 
    win.Paint.Add (fun e ->
        //e.Graphics.DrawLines (pen, (rotate (timer*System.Math.PI/60.0) hourHand))
        e.Graphics.DrawLines (pen, pts.[0]) // Takes input from model (hourHand)
        //e.Graphics.DrawLines (pen, pts.[1]) // Takes input from model (minuteHand)
        //e.Graphics.DrawLines (pen, pts.[2]) // Takes input from model (secondHand)
        e.Graphics.DrawEllipse (pen,10.0f,10.0f,160.0f,160.0f)
        let CenterDotBrush = new SolidBrush(Color.Red)
        e.Graphics.FillEllipse(CenterDotBrush,89.0f,89.0f,6.0f,6.0f))
    win.Invalidate()
    *)

    let black = new Pen ((Color.FromArgb (0, 0, 0)), Width=2.0f)
    let blue = new Pen ((Color.FromArgb (19, 76, 232)), Width=3.0f)
    let green = new Pen ((Color.FromArgb (0, 255, 0)), Width=1.0f)

    // Drawing the lines with index and drawing the circle, and invalidating 
    win.Paint.Add (fun e ->
        //e.Graphics.DrawLines (pen, (rotate (timer*System.Math.PI/60.0) hourHand))
        e.Graphics.DrawLines (black, [|Point (93,95);Point (93,20)|]) // Takes input from model (hourHand)
        e.Graphics.DrawLines (blue, [|Point (92,95);Point (92,45)|]) // Takes input from model (minuteHand)
        e.Graphics.DrawLines (green, [|Point (92,103);Point (92,20)|]) // Takes input from model (secondHand)
        e.Graphics.DrawEllipse (pen,10.0f,10.0f,160.0f,160.0f)
        let CenterDotBrush = new SolidBrush(Color.Red)
        e.Graphics.FillEllipse(CenterDotBrush,89.0f,89.0f,6.0f,6.0f))
    win.Invalidate()
    
(*
    /// ********* CenterDot (center af cirklen) *********
    win.Paint.Add(fun draw ->
        let CenterDotBrush = new SolidBrush(Color.Red)
        draw.Graphics.FillEllipse(CenterDotBrush,89.0f,89.0f,6.0f,6.0f))  
*)

    /// ********* Working Digital Clock *********
    // make a label to show time
    let digitalTimerLabel = new Label ()
    win.Controls.Add digitalTimerLabel
    digitalTimerLabel.Width <- 200
    digitalTimerLabel.Location <- new Point (40,190)
    digitalTimerLabel.Text <- string System.DateTime.Now // get present time and date

    // make a timer and link to label
    let timer = new Timer ()
    timer.Interval <- 60 // create an event every 1000 millisecond
    timer.Enabled <- true // activiate the timer
    timer.Tick.Add (fun e ->
        digitalTimerLabel.Text <- string System.DateTime.Now
      //  win.Paint.Add rotate; 
        win.Invalidate()
        )

    fun () -> Application.Run win // Function as return value 


/// ********* Model containing the clock hands (Ur-viserne) *********
(*
let model () : Size * Pen * (Point [] []) =
    let size = Size (183, 230)
    //let pen = new Pen (Color.Black,Width=2.0f)
    //               (Bottom cord) ;   (Top cord)
    //let hourHand   = [|Point(93,95); Point(93,20)|]
    //let minuteHand = [|Point(93,95); Point(93,20)|]
    //let secondHand = [|Point(93,95); Point(93,20)|]
    //let lines = [|hourHand|] //; minuteHand; secondHand|]
    (size, pen, lines)
*)

let model () : Size * Pen =
    let pen = new Pen (Color.Black,Width=2.0f)
    let size = Size (183, 230)
    (size, pen)

/// ********* Connection *********
(*
let (size, pen, lines) = model ()
let run = view size pen lines
run() // Start the event - loop
*)

let (size, pen) = model ()
let run = view size pen
run() // Start the event - loop

//Application.Run win // start event - loop
