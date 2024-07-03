# CrossCore-Lua-Tool

一个帮助你解密/加密CrossCore Luascripts的工具

## Command Line Arguments

- `--infile <infile>` or `-i <infile>`: Specifies the input lua file to be processed.
- `--outfile <outfile>` or `-o <outfile>`: Specifies the output file where the processed data will be written.
- `--encrypt` or `-e`: Encrypts the lua file.
- `--platform` or `-p`: Specifies the platform to use for encryption, Android or iOS(default: Android).
- `--decrypt` or `-d`: Decrypts the lua file.
- `--nofix`: Do not fix the file.
- `--ver-bytes`: Read version data from file.
- `--help` or `-h`: Show help.

Example usage:

```bash
./crosscore-lua-tool --infile ./path/to/infile --outfile ./path/to/outfile --encrypt
```

## Python Version

查看[pyScripts](https://github.com/AXiX-official/CrossCore-Lua-Tool/tree/pyScripts)分支