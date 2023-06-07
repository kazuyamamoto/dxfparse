open System.IO

// ファイルを読み1行ずつ返す。
let ReadLines (file: string) =
    seq {
        use reader = new StreamReader(file)

        while not reader.EndOfStream do
            yield reader.ReadLine()
    }

// 2行をペアとしたシーケンスを得る。
let LinePairs lines =
    lines
    |> Seq.indexed 
    |> Seq.groupBy (fun (index, _) -> index / 2)
    |> Seq.map snd
    |> Seq.map(fun seq -> (Seq.head seq, Seq.last seq))
    |> Seq.map(fun ((_, l1), (_, l2)) -> (l1, l2))

"sample.dxf"
|> ReadLines
|> LinePairs
|> Seq.map id
|> Seq.iter (fun pair -> printfn $"{pair}")
