import sys

def decrypt(source: str, target: str) -> None:
    with open(source, 'rb') as f:
        f.seek(152)
        data = bytearray(f.read())
    length = len(data)
    l = length // 100
    p = 0
    a = (length % 254) 
    while p < length:
        v = data[p]
        data[p] = v ^ a
        a = (data[p] + v) % 256
        p += l
    with open(target, 'wb') as f:
        f.write(data[:-1])

if __name__ == '__main__':
    if len(sys.argv) != 3:
        print('Usage: python Decrypt.py <source> <target>')
        print('<source>: the encrypted luascript file path')
        print('<target>: the path to save the decrypted luascript file')
    else:
        decrypt(sys.argv[1], sys.argv[2])