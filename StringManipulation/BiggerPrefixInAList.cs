//namespace StringManipulation
//{
//    public class BiggerPrefixInAList
//    {
//        public BiggerPrefixInAList()
//        {

//        }

//        private Dictionary<int, string> prefixesSize = [];

//        public string LongestCommonPrefix(string[] strs)
//        {
//            string result = "";

//            Array.Sort(strs);

//            int maxLenght = 0;

//            for (int i = 0; i < strs.Length - 1; i++)
//            {
//                for (int j = 2; j < strs[i].Length; j++)
//                {
//                    if (strs[i][..j] == strs[i + 1][..j])
//                    {
//                        if (!prefixesSize.Any(x => x.Key == j))
//                            prefixesSize.Add(j, strs[i][..j]);

//                        if (maxLenght < j)
//                            maxLenght = j;
//                        continue;
//                    }

//                    break;
//                }
//            }

//            if (maxLenght == 0)
//                return "";

//            return prefixesSize[maxLenght];
//        }
//    }
//}



namespace StringManipulation
{
    public class BiggerPrefixInAList
    {
        public BiggerPrefixInAList()
        {
        }

        private Dictionary<int, string> prefixesSize = [];

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 1)
                return strs[0];

            string result = "";

            Array.Sort(strs);

            var firstStr = strs[0];
            var lastStr = strs[strs.Length - 1];

            var lengthToSearch =
                firstStr.Length < lastStr.Length ?
                firstStr.Length :
                lastStr.Length;

            int maxLenght = 0;
            int possibleMaxLength = 0;

            for (int j = 1; j <= lengthToSearch; j++)
            {
                if (firstStr[..j] == lastStr[..j])
                {
                    if (!prefixesSize.Any(x => x.Key == j))
                        prefixesSize.Add(j, firstStr[..j]);

                    if (maxLenght < j)
                        maxLenght = j;

                    continue;
                }

                break;
            }

            if (maxLenght == 0)
                return "";

            return prefixesSize[maxLenght];
        }
    }
}

