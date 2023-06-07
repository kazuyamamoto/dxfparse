open System.IO

let ReadLines (file: string) : seq<string> =
    seq {
        use reader = new StreamReader(file)

        while not reader.EndOfStream do
            yield reader.ReadLine()
    }

let LinePairs (lines: seq<string>) : seq<string * string> =
    lines
    |> Seq.indexed
    |> Seq.groupBy (fun (index, _) -> index / 2)
    |> Seq.map snd
    |> Seq.map (fun seq -> (Seq.head seq, Seq.last seq))
    |> Seq.map (fun ((_, line1), (_, line2)) -> (line1, line2))

"sample.dxf"
|> ReadLines
|> LinePairs
|> Seq.iter (fun pair -> printfn $"{pair}")
