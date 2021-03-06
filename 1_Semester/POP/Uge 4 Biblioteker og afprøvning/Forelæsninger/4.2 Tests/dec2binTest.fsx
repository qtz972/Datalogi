// Unit : dec2bin
let dec2bin n =
  (* WB: 1 *)
  if n < 0 then
    "Illegal value"
  (* WB: 2 *)
  elif n = 0 then
    "0b0"
  else
    let mutable v = n
    let mutable str = ""
    (* WB: 3 *)
    while v > 0 do
      str <- (string (v % 2)) + str
      v <- v / 2
    "0b" + str

printfn "White-box testing of dec2bin.fsx"
printfn "  Unit: dec2bin"
printfn "    Branch: 1a - %b" (dec2bin -1 = "Illegal value")
printfn "    Branch: 2a - %b" (dec2bin 0 = "0b0")
printfn "    Branch: 3a - %b" (dec2bin 1 = "0b1")

printfn "Black-box testing of dec2bin.fsx"
printfn "  n < 0  - %b" (dec2bin -1 = "Illegal value")
printfn "  n = 0  - %b" (dec2bin 0 = "0b0")
printfn "  n = 1  - %b" (dec2bin 1 = "0b1")
printfn "  n = 2  - %b" (dec2bin 2 = "0b10")
printfn "  n = 10 - %b" (dec2bin 10 = "0b1010")
printfn "  n = 11 - %b" (dec2bin 11 = "0b1011")
