import requests
import sys
from typing import Tuple

def get_target_size_and_header(platform: str) -> Tuple[int, bytearray]:
    platform = platform.lower()
    lua_file_url = ""
    if platform == 'android':
        lua_file_url = "https://cdn.megagamelog.com/cross/release/android/curr/Custom/luascripts" 
    elif platform == 'ios':
        lua_file_url = "https://cdn.megagamelog.com/cross/release/ios/curr/Custom/luascripts"
    else:
        raise ValueError(f'Invalid platform {platform}')
    response = requests.head(lua_file_url)
    size = response.headers.get('Content-Length', 0)
    # 文件前153字节
    header = bytearray(requests.get(lua_file_url).content[:152])
    return int(size), header



def encrypt(source: str, target: str, platform: str) -> None:
    with open(source, 'rb') as f:
        data = bytearray(f.read())
    length = len(data)
    target_size, header = get_target_size_and_header(platform)
    if length + 153 > target_size:
        raise ValueError(f'The size of the source file is too large, the maximum size is {target_size} but the source file size is {length}')
    elif length + 153 < target_size:
        data.extend(b'\x00' * (target_size - length - 153))
    l = (target_size - 152) // 100
    p = 0
    a = ((target_size - 152) % 254) 
    while p < target_size - 152:
        v = data[p]
        data[p] = v ^ a
        a = (data[p] + v) % 256
        p += l
    with open(target, 'wb') as f:
        f.write(header)
        f.write(data)
        f.write(b'\x0B')

if __name__ == '__main__':
    if len(sys.argv) != 4:
        print('Usage: python Encrypt.py <source> <target> <platform>')
        print('<source>: the luascript file path to encrypt')
        print('<target>: the path to save the encrypted luascript file')
        print('<platform>: Android or iOS')
    else:
        encrypt(sys.argv[1], sys.argv[2], sys.argv[3])