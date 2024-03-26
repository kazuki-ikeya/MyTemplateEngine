param ([string]$scriptDirectory)

# スクリプトが配置されたディレクトリを取得
if ($scriptDirectory -eq "") {
	$scriptDirectory = Split-Path -Parent $MyInvocation.MyCommand.Path
}

$exePath = $scriptDirectory + "exe\net8.0\MyTemplateEngineForRazor.exe"

# Tsvファイルを読み込む
$fileListPath = "./filelist.tsv" 
$fileList = Get-Content -Path $fileListPath | ConvertFrom-Csv -Delimiter "`t" -Header ("ImportPath", "ExportFileName")
foreach ($row in $fileList) {
    $targetFilePath = $row.ImportPath
    $target = Get-Content -Path $targetFilePath -Raw | ConvertFrom-Json
    
    # テンプレートファイルパス
    $arg1 = $scriptDirectory + "baseFormat.cshtml" 
    # Modelファイルパス
    $arg2 = $scriptDirectory + $targetFilePath
    # 出力ファイルパス
    $outputPath = "./results/" + $row.ExportFileName
    $arg3 = $scriptDirectory + $outputPath
    
    # 変換開始
    Write-Host $row
    Start-Process -FilePath $exePath -ArgumentList $arg1, $arg2, $arg3 -NoNewWindow -Wait
}

Read-Host "出力完了"
