// Christian Sass Hansen
// Last edited 06/11-2017

open ImgUtil
let rec spiral bmp s i x y =
    if i >= 450 then ()
    else
        let p1 = (x,y)
        let p2 = (x+i,y)
        let p3 = (x+i,y+i)
        let p4 = (x-s,y+i)
        let p5 = (x-s,y-s)
        do setLine red p1 p2 bmp
        do setLine red p2 p3 bmp
        do setLine red p3 p4 bmp
        do setLine red p4 p5 bmp
        spiral bmp s (i+2*s) (x-s) (y-s)

do runSimpleApp "Spiral" 550 550 (fun bmp -> spiral bmp 10 10 250 250 |> ignore)
