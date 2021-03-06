/// Listing 23.4 winforms/triangle
/// Adding line greaphics to a window.
/// Shown down-under:

// Open often used libraries, be ware of namespace polution!
open System.Windows.Forms
open System.Drawing

// Prepare window form
let win = new Form ()
win.Size <- Size (320, 170)

// Set paint call-back function
let paint (e : PaintEventArgs) : unit =
    let pen = new Pen (Color.Black)
    let points =
        [|Point (0,0); Point (10,170); Point (320,20); Point (0,0)|]
    e.Graphics.DrawLines (pen, points)
win.Paint.Add paint

// Start the event-loop
Application.Run win // Start the event-loop