open System
open System.IO

let readLines (file: string) =
    seq {
        use reader = new StreamReader(file)

        while not reader.EndOfStream do
            yield reader.ReadLine()
    }

"sample.dxf" |> readLines |> Seq.iter (fun line -> printfn $"{line}")
