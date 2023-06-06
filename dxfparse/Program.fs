open System.IO

let ReadLines (file: string) =
    seq {
        use reader = new StreamReader(file)

        while not reader.EndOfStream do
            yield reader.ReadLine()
    }

"sample.dxf"
|> ReadLines
// いつ自動フォーマットで改行するのかを確認するための無意味な処理（id は　入出力が同じことを表す関数）
|> Seq.map id
|> Seq.iter (fun line -> printfn $"{line}")
