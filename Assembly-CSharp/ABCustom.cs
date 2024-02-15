[System.Serializable]
public class ABCustom
{

    static int[] arrEncypt = { 2,3,1,1,3,1,2,1,1,3,1,2,4,1,1,2,2,4,4 };
    public static string DdooEennccyyppttSsttrr(string str)
    {
        char[] strArr = str.ToCharArray();
        
        int indexArr = 0;

        int len = str.Length;
        for (int i = 0; i < len;) 
        {
            int arrEncyptVal = arrEncypt[indexArr++];
            indexArr %= arrEncypt.Length;

            int j = i + arrEncyptVal;
            if (j >= len) { break; }

            char a = strArr[i];
            strArr[i] = strArr[j];
            strArr[j] = a;
            ///Debug.LogError(string.Format("{0}:{1}=>{2}:{3}",i,strArr[j],j,strArr[i]));
            i = j + 1;
        }
        str = new string(strArr);
        return str;
    }
    public byte[] bytes;
    string abPath = "";
    public static void DdooEennccyypptt(ref byte[] targetData)
    {
        byte key = (byte)(targetData.Length % 254 + 1);// keys[targetData.Length % keys.Length];
        int step = Math.Max(1,targetData.Length / 100);
        //加密，与key异或，解密的时候同样如此
        int dataLength = targetData.Length;
        for (int i = 0; i < dataLength; i += step)
        {
            byte originValue = targetData[i];
            targetData[i] = (byte)(targetData[i] ^ key);
            key = (byte)(originValue + targetData[i]);
        }
    }
}