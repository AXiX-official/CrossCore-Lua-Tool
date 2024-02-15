# CrossCore-Lua-Tool

一个帮助你解密/加密CrossCore Luascripts的工具

## Command Line Arguments

- `--rawfile <rawfile>` or `-r <rawfile>`: Specifies the raw file to be processed.
- `--outfile <outfile>` or `-o <outfile>`: Specifies the output file where the processed data will be written.
- `--encrypt`: Encrypts the raw file.
- `--decrypt`: Decrypts the raw file.


Example usage:

```bash
./crosscore-lua-tool --rawfile ./path/to/rawfile --outfile ./path/to/outfile --encrypt
```