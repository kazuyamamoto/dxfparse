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
    |> Seq.map (fun ((_, line1), (_, line2)) -> (line1.Trim(), line2))

"sample.dxf" |> ReadLines |> LinePairs |> Seq.iter (printfn "%A")

let Section (pairs: seq<string * string>) =
    let sectionStart pair =
        match pair with
        | "0", "SECTION" -> false
        | _ -> true
    let sectionEnd pair =
        match pair with
        | "0", "ENDSEC" -> false
        | _ -> true
    pairs
    |> Seq.skipWhile sectionStart
    |> Seq.takeWhile sectionEnd
