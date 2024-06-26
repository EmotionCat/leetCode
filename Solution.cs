public class Solution
{
    //50.最后一个单词的长度(简单，字符串)
    public int LengthOfLastWord(string s)
    {
        string[] strs = s.Split(" ");
        int length = 0;
        for (int i = strs.Length - 1; i >= 0; i--)
        {
            if (strs[i].Length > 0)
            {
                length = strs[i].Length;
                break;
            }
        }
        return length;
    }

    // 67.二进制求和(简单，字符串)
    // 给你两个二进制字符串 a 和 b ，以二进制字符串的形式返回它们的和。
    // 示例1：输入：a = "11", b = "1", 输出："100"
    // 示例2：输入：a = "1010", b = "1011", 输出："10101"
    public string AddBinary(string a, string b) 
    {
        char[] charsA = new char[a.Length];
        char[] charsB = new char[b.Length];
        string result = "";
        int i = a.Length - 1;
        foreach(char ch in a)
        {
            charsA[i] = ch;
            i--;
        }
        i = b.Length - 1;
        foreach(char ch in b)
        {
            charsB[i] = ch;
            i--;
        }
        int count = a.Length < b.Length ? a.Length : b.Length;
        int flag = 0;
        for (i = 0; i < count; i++)
        {
            if (charsA[i] == '0' && charsB[i] == '0')
            {
                if (flag == 0) result += "0";
                else result += "1";
                flag = 0;
            }
            else if (charsA[i] == '1' && charsB[i] == '1')
            {
                if (flag == 0) result += "0";
                else result += "1";
                flag = 1;
            }
            else if (charsA[i] == '1' || charsB[i] == '1')
            {
                if (flag == 0) result += "1";
                else
                {
                    result += "0";
                    flag = 1;
                }
            }else{}
        }
        
        if (count < a.Length)
        {
            for (;i < a.Length; i++)
            {
                if (flag == 0 && charsA[i] == '0') result += "0";
                else if (flag == 1 && charsA[i] == '1') result += '0';
                else if (flag == 1 || charsA[i] == '1')
                {
                    result += '1';
                    flag = 0;
                }else{}
            }   
        }
        else if (count < b.Length)
        {
            for (;i < b.Length; i++)
            {
                if (flag == 0 && charsB[i] == '0') result += "0";
                else if (flag == 1 && charsB[i] == '1') result += '0';
                else if (flag == 1 || charsB[i] == '1')
                {
                    result += '1';
                    flag = 0;
                }else{}
            }
        }
        if (flag == 1) result += "1";
        char[] sum = new char[result.Length];
        i = result.Length - 1;
        foreach (char ch in result)
        {
            sum[i] = ch;
            i--;
        }
        result = "";
        for (i = 0; i < sum.Length; i++)
        {
            result += sum[i];
        }
        return result;
    }

    //169.多数元素(简单，排序)
    // 给定一个大小为 n 的数组 nums ，返回其中的多数元素。多数元素是指在数组中出现次数 大于 ⌊ n/2 ⌋ 的元素。
    // 你可以假设数组是非空的，并且给定的数组总是存在多数元素。
    // 示例1：输入：nums = [3, 2, 3], 输出：3
    // 示例2：输入：nums = [2,2,1,1,1,2,2], 输出：2
    public int MajorityElement(int[] nums)
    {
        int count = 0;
        int num = -1;
        Array.Sort(nums);     
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] != nums[i + 1])
            {
                if (i - count + 1 > count) 
                {
                    count = i - count + 1;
                    num = nums[i];
                }
            }
        }
        if (nums.Length - count > count) num = nums[nums.Length - 1];
        return num;
    }

    //66.加一(简单，数组)
    // 给定一个由 整数 组成的 非空 数组所表示的非负整数，在该数的基础上加一。
    // 最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。
    // 你可以假设除了整数 0 之外，这个整数不会以零开头。
    // 示例1：输入：[1, 2, 3], 输出：[1, 2, 4]
    // 示例2：输入：[4, 3, 2, 1], 输出：[4, 3, 2, 2]
    public int[] PlusOne(int[] digits) 
    {
        string str = "";
        foreach (int num in digits)
        {
            str += num.ToString();
        }
        int length = str.Length;
        char[] chars = str.Reverse().ToArray();
        int count = (int)(chars[0] - '0') + 1;
        int flag = 0;
        if (count < 10) chars[0] = (char)(count + '0');
        else
        {
            flag = 1;
            for(int i = 0; i < chars.Length; i++)
            {
                count = (int)(chars[i] - '0') + flag;
                if (count < 10)
                {
                    chars[i] = (char)(count + '0');
                    flag = 0;
                    break;
                }
                else
                {
                    chars[i] = (char)(count % 10 + '0');
                }
            }
        } 
        str = new string(chars);
        if (flag == 1)
        {
            str +='1';
        }
        length = str.Length;
        int[] result = new int[length];
        for(int i = 0; i < length; i++)
        {
            result[i] = (int)(str[length - 1 - i] - '0');
        }        
        return result;
    }

    //125.验证回文串(简单，字符串)
    // 如果在将所有大写字符转换为小写字符、并移除所有非字母数字字符之后，短语正着读和反着读都一样。则可以认为该短语是一个 回文串 。
    // 字母和数字都属于字母数字字符。
    // 给你一个字符串 s，如果它是 回文串 ，返回 true ；否则，返回 false 。
    // 示例1：输入：s = "A man, a plan, a canal: Panama" 输出：true
    // 示例2：s = "race a car" 输出：false
    public bool IsPalindrome(string s) 
    {
        string str = "";
        foreach (char ch in s)
        {
            if ((ch > 47 && ch < 58) || (ch > 96 && ch < 123) || (ch > 64 && ch < 91))
                str += ch;
        }
        str = str.ToLower();
        if (str.Length % 2 == 1)
        {
            for (int i = 0; i < (str.Length + 1) / 2; i++)
            {
                if (str[i] != str[str.Length - 1 - i])
                    return false;
            }
        }
        else
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - 1 - i])
                    return false;
            }
        }
        return true;
    }

    //217.存在重复元素(简单，排序)
    // 给你一个整数数组nums。如果任一值在数组中出现至少两次 ，返回true；如果数组中每个元素互不相同，返回false。
    // 示例1：输入：nums = [1,2,3,1]，输出：true
    // 示例2：输入：nums = [1,2,3,4]，输出：false
    // 示例3：输入：nums = [1,1,1,3,3,4,3,2,4,2]，输出：true
    public bool ContainsDuplicate(int[] nums) 
    {
        HashSet<int> set = new HashSet<int>();
        set.Clear();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!set.Add(nums[i]))
            {
                return true;
            }
        }
        return false;
    }

    //242.有效的字母异位词(简单，排序)
    // 给定两个字符串 s 和 t ，编写一个函数来判断 t 是否是 s 的字母异位词。
    // 注意：若 s 和 t 中每个字符出现的次数都相同，则称 s 和 t 互为字母异位词。
    // 示例1：输入: s = "anagram", t = "nagaram"，输出: true
    // 示例2：输入: s = "rat", t = "car"，输出: false
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        int[] count = new int[26];
        HashSet<char> set = new HashSet<char>();
        set.Clear();
        
        foreach (char ch in s)
        {
            if (!set.Add(ch))
            {
                count[(int)(ch - 'a')]++;
            }
        }
        foreach (char ch in t)
        {
            if (set.Add(ch)) return false;
            if (count[(int)(ch - 'a')] == 0) set.Remove(ch);
            else if (count[(int)(ch - 'a')] != 0) count[(int)(ch - 'a')]--;
            else{}
        }
        if (set.Count != 0) return false;
        for (int i = 0; i < 26; i++)
        {
            if (count[i] != 0) return false;
        }
        return true;
    }

    //268.丢失的数字(简单，排序)
    // 给定一个包含 [0, n] 中 n 个数的数组 nums ，找出 [0, n] 这个范围内没有出现在数组中的那个数。
    // 示例1：输入：nums = [3,0,1]，输出：2
    // 示例2；输入：nums = [0,1]，输出：2
    // 示例3：输入：nums = [9,6,4,2,3,5,7,0,1]，输出：8
    // 示例4：输入：nums = [0]，输出：1
    public int MissingNumber(int[] nums)
    {
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != i) return i;
        }
        return nums.Length;
    }

    //349.两个数组的交集(简单，排序)
    // 给定两个数组 nums1 和 nums2 ，返回它们的交集。输出结果中的每个元素一定是唯一的。我们可以不考虑输出结果的顺序。
    // 示例1：输入：nums1 = [1,2,2,1], nums2 = [2,2]，输出：[2]
    // 示例2：输入：nums1 = [4,9,5], nums2 = [9,4,9,8,4]，输出：[9,4]，解释：[4,9] 也是可通过的
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        HashSet<int> set = new HashSet<int>();
        HashSet<int> set1 = new HashSet<int>();
        HashSet<int> set2 = new HashSet<int>();
        foreach (int num in nums1)
        {
            set1.Add(num);
        }
        foreach (int num in nums2)
        {
            set2.Add(num);
        }
        foreach (int num in set1)
        {
            if (!set2.Add(num)) set.Add(num);
        }
        int[] result = new int[set.Count];
        List<int> list = new List<int>(set);
        for (int i = 0; i < list.Count; i++)
        {
            result[i] = list[i];
        }
        return result;
    }
    //463.岛屿的周长(简单，矩阵)
    // 给定一个 row x col 的二维网格地图 grid ，其中：grid[i][j] = 1 表示陆地， grid[i][j] = 0 表示水域。
    // 网格中的格子 水平和垂直 方向相连（对角线方向不相连）。整个网格被水完全包围，但其中恰好有一个岛屿（或者说，一个或多个表示陆地的格子相连组成的岛屿）。
    // 岛屿中没有“湖”（“湖” 指水域在岛屿内部且不和岛屿周围的水相连）。格子是边长为 1 的正方形。网格为长方形，且宽度和高度均不超过 100 。计算这个岛屿的周长。
    public int IslandPerimeter(int[][] grid)
    {
        // 第一个思路：判断当前是否为陆地，是，边长 +4，再次判断上下左右是否为陆地，有一个 -1；否，边长 +0；
        int row = grid.GetLength(0);
        int col = grid[0].Length;
        int side = 0;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if(grid[i][j] == 1)
                {
                    side += 4;
                    try
                    {
                        if (grid[i - 1][j] == 1) side--;
                    }
                    catch{}
                    try
                    {
                        if (grid[i + 1][j] == 1) side--;
                    }
                    catch{}
                    try
                    {
                        if (grid[i][j - 1] == 1) side--;
                    }
                    catch{}
                    try
                    {
                        if (grid[i][j + 1] == 1) side--;
                    }
                    catch{}
                }
            }
        }
        return side;
    }

    //566.重塑矩阵(简单，矩阵)
    // 在 MATLAB 中，有一个非常有用的函数 reshape ，它可以将一个 m x n 矩阵重塑为另一个大小不同（r x c）的新矩阵，但保留其原始数据。
    // 给你一个由二维数组 mat 表示的 m x n 矩阵，以及两个正整数 r 和 c ，分别表示想要的重构的矩阵的行数和列数。
    // 重构后的矩阵需要将原始矩阵的所有元素以相同的 行遍历顺序 填充。
    // 如果具有给定参数的 reshape 操作是可行且合理的，则输出新的重塑矩阵；否则，输出原始矩阵。
    // 示例1：输入：mat = [[1,2],[3,4]], r = 1, c = 4，输出：[[1,2,3,4]]
    // 示例2：输入：mat = [[1,2],[3,4]], r = 2, c = 4，输出：[[1,2],[3,4]]
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        // 思路：先拉成一维数组。在填入新数组，，，，，不，直接计算得到当前数据在新数组的位置，直接填入
        int row = mat.GetLength(0);
        int col = mat[0].Length;
        if (row * col != r * c) return mat;
        int[][] result = new int[r][];
        for (int i = 0; i < r; i++)
        {
            result[i] = new int[c];
        }
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                int rows;
                int cols;
                if ((i * c + j + 1) % col == 0)
                {
                    rows = (i * c + j + 1) / col - 1;
                    cols = col - 1;
                }
                else
                {
                    rows = (i * c + j + 1) / col;
                    cols = (i * c + j + 1) % col - 1;
                }
                result[i][j] = mat[rows][cols];
            }
        }
        return result;
    }

    //661.图片平滑器(简单，矩阵)
    // 图像平滑器 是大小为 3 x 3 的过滤器，用于对图像的每个单元格平滑处理，平滑处理后单元格的值为该单元格的平均灰度。
    // 每个单元格的  平均灰度 定义为：该单元格自身及其周围的 8 个单元格的平均值，结果需向下取整。（即，需要计算蓝色平滑器中 9 个单元格的平均值）。
    // 如果一个单元格周围存在单元格缺失的情况，则计算平均灰度时不考虑缺失的单元格（即，需要计算红色平滑器中 4 个单元格的平均值）。
    // 示例1：输入:img = [[1,1,1],[1,0,1],[1,1,1]]，输出:[[0, 0, 0],[0, 0, 0], [0, 0, 0]]
    // 解释:
    // 对于点 (0,0), (0,2), (2,0), (2,2): 平均(3/4) = 平均(0.75) = 0
    // 对于点 (0,1), (1,0), (1,2), (2,1): 平均(5/6) = 平均(0.83333333) = 0
    // 对于点 (1,1): 平均(8/9) = 平均(0.88888889) = 0
    // 示例2：输入: img = [[100,200,100],[200,50,200],[100,200,100]]，输出: [[137,141,137],[141,138,141],[137,141,137]]
    // 解释:
    // 对于点 (0,0), (0,2), (2,0), (2,2): floor((100+200+200+50)/4) = floor(137.5) = 137
    // 对于点 (0,1), (1,0), (1,2), (2,1): floor((200+200+50+200+100+100)/6) = floor(141.666667) = 141
    // 对于点 (1,1): floor((50+200+200+200+200+100+100+100+100)/9) = floor(138.888889) = 138
    public int[][] ImageSmoother(int[][] img)
    {
        int imgRow = img.GetLength(0);
        int imgCol = img[0].Length;
        int[][] result = new int[imgRow][];
        for (int i = 0; i < imgRow; i++)
        {
            result[i] = new int[imgCol];
        }
        
        for (int i = 0; i < imgRow; i++)
        {
            
            for (int j = 0; j < imgCol; j++)
            {
                int sum = img[i][j];
                int count = 1;
                int up = 0;
                int down = 0;
                int left = 0;
                int right = 0;
                if (i - 1 < 0) up = -1;
                if (i == imgRow - 1) down = -1;
                if (j - 1 < 0) left = -1;
                if (j == imgCol -1) right = -1;
                // 上方一排
                if (up == 0)
                {
                    sum += img[i - 1][j];
                    count++;
                    if (left == 0)
                    {
                        sum += img[i - 1][j - 1];
                        count++;
                    }
                    if (right == 0) 
                    {
                        sum += img[i - 1][j + 1];
                        count++;
                    }
                }
                // 左边一个
                if (left == 0)
                {
                    sum += img[i][j - 1];
                    count++;
                }
                // 右边一个
                if (right == 0)
                {
                    sum += img[i][j + 1];
                    count++;
                }
                // 下方一排
                if (down == 0)
                {
                    sum += img[i + 1][j];
                    count++;
                    if (left == 0)
                    {
                        sum += img[i + 1][j - 1];
                        count++;
                    }
                    if (right == 0) 
                    {
                        sum += img[i + 1][j + 1];
                        count++;
                    }
                }
                result[i][j] = sum / count;
            }
        }
        return result;
    }

    //733.图像渲染(简单，矩阵)
    // 有一幅以 m x n 的二维整数数组表示的图画 image ，其中 image[i][j] 表示该图画的像素值大小。
    // 你也被给予三个整数 sr ,  sc 和 newColor 。你应该从像素 image[sr][sc] 开始对图像进行 色填充 。
    // 为了完成上色工作，从初始像素开始，记录初始坐标的上下左右四个方向上像素值与初始坐标相同的相连像素点，接着再记录这四个方向上符合条件的像素点与他们对应四个方向上像素值与初始坐标相同的相连像素点，……，重复该过程。将所有有记录的像素点的颜色值改为 newColor 。
    // 最后返回经过上色渲染后的图像。
    // 示例1：输入: image = [[1,1,1],[1,1,0],[1,0,1]]，sr = 1, sc = 1, newColor = 2，输出: [[2,2,2],[2,2,0],[2,0,1]]
    // 解析: 在图像的正中间，(坐标(sr,sc)=(1,1)),在路径上所有符合条件的像素点的颜色都被更改成2。
    // 注意，右下角的像素没有更改为2，因为它不是在上下左右四个方向上与初始点相连的像素点。
    // 示例2：输入: image = [[0,0,0],[0,0,0]], sr = 0, sc = 0, newColor = 2，输出: [[2,2,2],[2,2,2]]
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        // 思路：递归
        // 防止一直不出来，把经过的路径标出来
        int imgRow = image.GetLength(0);
        int imgCol = image[0].Length;
        int[][] path = new int[imgRow][];
        for (int i = 0; i < imgRow; i++)
        {
            path[i] = new int[imgCol];
        }
        int num = image[sr][sc];
        image[sr][sc] = color;
        CheckNode(image, sr, sc, num, color, path);
        return image;
    }
    public void CheckNode(int[][] image, int row, int col, int num, int color, int[][] path)
    {
        if (path[row][col] == 1) return;
        path[row][col] = 1;
        int imgRow = image.GetLength(0);
        int imgCol = image[0].Length;
        // 上方
        if (row != 0 && image[row - 1][col] == num)
        {
            image[row - 1][col] = color;
            CheckNode(image, row - 1, col, num, color, path);
        }
        // 下方
        if (row != imgRow - 1 && image[row + 1][col] == num)
        {
            image[row + 1][col] = color;
            CheckNode(image, row + 1, col, num, color, path);
        }
        // 左方
        if (col != 0 && image[row][col - 1] == num)
        {
            image[row][col - 1] = color;
            CheckNode(image, row, col - 1, num, color, path);
        }
        // 右方
        if (col != imgCol - 1 && image[row][col + 1] == num)
        {
            image[row][col + 1] = color;
            CheckNode(image, row, col + 1, num, color, path);
        }
    }

    //766.托普利茨矩阵(简单，矩阵)
    // 给你一个 m x n 的矩阵 matrix 。如果这个矩阵是托普利茨矩阵，返回 true ；否则，返回 false 。
    // 如果矩阵上每一条由左上到右下的对角线上的元素都相同，那么这个矩阵是 托普利茨矩阵 。
    // 示例1：输入：matrix = [[1,2,3,4],[5,1,2,3],[9,5,1,2]]，输出：true
    // 解释：
    // 在上述矩阵中, 其对角线为: 
    // "[9]", "[5, 5]", "[1, 1, 1]", "[2, 2, 2]", "[3, 3]", "[4]"。 
    // 各条对角线上的所有元素均相同, 因此答案是 True 。
    // 示例2：输入：matrix = [[1,2],[2,2]]，输出：false
    // 解释：
    // 对角线 "[1, 2]" 上的元素不同。
    public bool IsToeplitzMatrix(int[][] matrix)
    {
        int matrixRow = matrix.GetLength(0);
        int matrixCol = matrix[0].Length;
        for (int i = 0; i < matrixRow - 1; i++)
        {
            for (int j = 0; j < matrixCol - 1; j++)
            {
                if (matrix[i][j] != matrix[i + 1][j + 1]) return false;
            }
        }
        return true;
    }

    //832.翻转图像(简单，矩阵)
    // 给定一个 n x n 的二进制矩阵 image ，先水平翻转图像，然后反转图像并返回结果 。
    // 水平翻转图片就是将图片的每一行都进行翻转，即逆序。
    // 例如，水平翻转 [1,1,0] 的结果是 [0,1,1]。
    // 反转图片的意思是图片中的 0 全部被 1 替换， 1 全部被 0 替换。
    // 例如，反转 [0,1,1] 的结果是 [1,0,0]。
    // 示例1：输入：image = [[1,1,0],[1,0,1],[0,0,0]]，输出：[[1,0,0],[0,1,0],[1,1,1]]
    // 解释：首先翻转每一行: [[0,1,1],[1,0,1],[0,0,0]]；
    // 然后反转图片: [[1,0,0],[0,1,0],[1,1,1]]
    // 示例2：输入：image = [[1,1,0,0],[1,0,0,1],[0,1,1,1],[1,0,1,0]]，输出：[[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
    // 解释：首先翻转每一行: [[0,0,1,1],[1,0,0,1],[1,1,1,0],[0,1,0,1]]；
    // 然后反转图片: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
    public int[][] FlipAndInvertImage(int[][] image) {
        int imageRow = image.GetLength(0);
        int imageCol = image[0].Length;
        for (int i = 0; i < imageRow; i++)
        {
            for (int j = 0; j < imageCol / 2; j++)
            {
                int temp = image[i][j];
                image[i][j] = image[i][imageCol - j - 1];
                image[i][imageCol - j - 1] = temp;

            }
        }
        for (int i = 0; i < imageRow; i++)
        {
            for (int j = 0; j < imageCol; j++)
            {
                if (image[i][j] == 0) image[i][j] = 1;
                else if (image[i][j] == 1) image[i][j] = 0;
            }
        }
        return image;
    }

    //258.各位相加(简单，模拟)
    // 给定一个非负整数 num，反复将各个位上的数字相加，直到结果为一位数。返回这个结果。
    // 示例1：输入: num = 38，输出: 2 
    // 解释: 各位相加的过程为：
    // 38 --> 3 + 8 --> 11
    // 11 --> 1 + 1 --> 2
    // 由于 2 是一位数，所以返回 2。
    // 示例2：输入: num = 0，输出: 0
    public int AddDigits(int num)
    {
        string str = num.ToString();
        while (num >= 10)
        {
            num = 0;
            foreach (char ch in str)
            {
                num += (int)(ch - '0');
            }
            str = num.ToString();
        }
        return num;
    }

    //412.Fizz Buzz(简单, 模拟)
    // 给你一个整数 n ，找出从 1 到 n 各个整数的 Fizz Buzz 表示，并用字符串数组 answer（下标从 1 开始）返回结果，其中：
    // answer[i] == "FizzBuzz" 如果 i 同时是 3 和 5 的倍数。
    // answer[i] == "Fizz" 如果 i 是 3 的倍数。
    // answer[i] == "Buzz" 如果 i 是 5 的倍数。
    // answer[i] == i （以字符串形式）如果上述条件全不满足。
    // 示例1：输入：n = 3，输出：["1","2","Fizz"]
    // 示例2：输入：n = 5，输出：["1","2","Fizz","4","Buzz"]
    // 示例3：输入：n = 15，输出：["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]
    public IList<string> FizzBuzz(int n) 
    {
        List<string> list = new List<string>();
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0) list.Add("FizzBuzz");
            else if (i % 3 == 0) list.Add("Fizz");
            else if (i % 5 == 0) list.Add("Buzz");
            else list.Add($"{i}");
        }
        return list;
    }

    //415.字符串相加(简单, 模拟)
    // 给定两个字符串形式的非负整数 num1 和num2 ，计算它们的和并同样以字符串形式返回。
    // 你不能使用任何內建的用于处理大整数的库（比如 BigInteger）， 也不能直接将输入的字符串转换为整数形式。
    // 示例1：输入：num1 = "11", num2 = "123"，输出："134"
    // 示例2：输入：num1 = "456", num2 = "77"，输出："533"
    // 示例3：输入：num1 = "0", num2 = "0"，输出："0"
    public string AddStrings(string num1, string num2)
    {
        string str = "";
        int flag = 0;
        char[] chars = num1.Reverse().ToArray();
        num1 = new string(chars);
        chars = num2.Reverse().ToArray();
        num2 = new string(chars);
        if (num1.Length >= num2.Length)
        {
            for (int i = 0; i < num2.Length; i++)
            {
                int count1 = (int)(num1[i] - '0');
                int count2 = (int)(num2[i] - '0');
                str += ((count1 + count2 + flag) % 10).ToString();
                if (count1 + count2 + flag >= 10) flag = 1;
                else flag = 0;
            }
            for (int i = num2.Length; i < num1.Length; i++)
            {
                int count = (int)(num1[i] - '0');
                str +=((count + flag) % 10).ToString();
                if (count + flag >= 10) flag = 1;
                else flag = 0;
            }
        }
        else if (num1.Length < num2.Length)
        {
            for (int i = 0; i < num1.Length; i++)
            {
                int count1 = (int)(num1[i] - '0');
                int count2 = (int)(num2[i] - '0');
                str += ((count1 + count2 + flag) % 10).ToString();
                if (count1 + count2 + flag >= 10) flag = 1;
                else flag = 0;
            }
            for (int i = num1.Length; i < num2.Length; i++)
            {
                int count = (int)(num2[i] - '0');
                str +=((count + flag) % 10).ToString();
                if (count + flag >= 10) flag = 1;
                else flag = 0;
            }
        }
        if (flag == 1) str += "1";
        chars = str.Reverse().ToArray();
        str = new string(chars);
        return str;
    }

    //1534.统计好三元组(简单, 枚举)
    // 给你一个整数数组 arr ，以及 a、b 、c 三个整数。请你统计其中好三元组的数量。
    // 如果三元组 (arr[i], arr[j], arr[k]) 满足下列全部条件，则认为它是一个好三元组。
    // 0 <= i < j < k < arr.length
    // |arr[i] - arr[j]| <= a
    // |arr[j] - arr[k]| <= b
    // |arr[i] - arr[k]| <= c
    // 其中 |x| 表示 x 的绝对值。
    // 返回好三元组的数量。
    // 示例1：输入：arr = [3,0,1,1,9,7], a = 7, b = 2, c = 3，输出：4
    // 解释：一共有 4 个好三元组：[(3,0,1), (3,0,1), (3,1,1), (0,1,1)]。
    // 示例2：输入：arr = [1,1,2,2,3], a = 0, b = 0, c = 1，输出：0
    // 解释：不存在满足所有条件的三元组。
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        int count = 0;
        for (int i = 0; i < arr.Length - 2; i++)
        {
            for (int j = i + 1; j < arr.Length - 1; j++)
            {
                for (int k = j + 1; k < arr.Length; k++)
                {
                    if (Math.Abs(arr[i] - arr[k]) <= c)
                    {
                        if (Math.Abs(arr[i] - arr[j]) <= a)
                        {
                            if (Math.Abs(arr[j] - arr[k]) <= b) count++;
                        }
                    }
                }
            }
        }
        return count;
    }

    //1566.重复至少 K 次且长度为 M 的模式(简单, 枚举)
    // 给你一个正整数数组 arr，请你找出一个长度为 m 且在数组中至少重复 k 次的模式。
    // 模式是由一个或多个值组成的子数组（连续的子序列），连续重复多次但不重叠。 模式由其长度和重复次数定义。
    // 如果数组中存在至少重复 k 次且长度为 m 的模式，则返回 true ，否则返回  false 。
    // 示例1：输入：arr = [1,2,4,4,4,4], m = 1, k = 3，输出：true
    // 解释：模式 (4) 的长度为 1 ，且连续重复 4 次。注意，模式可以重复 k 次或更多次，但不能少于 k 次。
    // 示例2：输入：arr = [1,2,1,2,1,1,1,3], m = 2, k = 2，输出：true
    // 解释：模式 (1,2) 长度为 2 ，且连续重复 2 次。另一个符合题意的模式是 (2,1) ，同样重复 2 次。
    // 示例3：输入：arr = [1,2,1,2,1,3], m = 2, k = 3，输出：false
    // 解释：模式 (1,2) 长度为 2 ，但是只连续重复 2 次。不存在长度为 2 且至少重复 3 次的模式。
    // 示例4：输入：arr = [1,2,3,1,2], m = 2, k = 2，输出：false
    // 解释：模式 (1,2) 出现 2 次但并不连续，所以不能算作连续重复 2 次。
    // 示例5：输入：arr = [2,2,2,2], m = 2, k = 3，输出：false
    // 解释：长度为 2 的模式只有 (2,2) ，但是只连续重复 2 次。注意，不能计算重叠的重复次数。
    public bool ContainsPattern(int[] arr, int m, int k)
    {
        if (m * k > arr.Length) return false;
        int flagK = 0;
        for (int i = 0; i < arr.Length - m * k + 1; i++)
        {
            for (int j = 0; j < m; j++)
            {
                for (int l = 1; l < k; l++)
                {
                    if (arr[i + j] != arr[i + j + l * m])
                    {
                        flagK = -1;
                        break;
                    }
                }
                if(flagK == -1) break;
            }
            if (flagK != -1) return true;
            flagK = 0;
        }
        return false;
    }

    //1925.统计平方和三元组的数目(简单, 枚举)
    // 一个平方和三元组 (a,b,c) 指的是满足 a^2 + b^2 = c^2 的整数三元组 a，b 和 c。
    // 给你一个整数 n ，请你返回满足 1 <= a, b, c <= n 的平方和三元组的数目。
    // 示例1：输入：n = 5, 输出：2
    // 解释：平方和三元组为 (3,4,5) 和 (4,3,5)。
    // 示例2：输入：n = 10, 输出：4
    // 解释：平方和三元组为 (3,4,5), (4,3,5), (6,8,10) 和 (8,6,10)。
    public int CountTriples(int n)
    {
        int count = 0;
        for (int i = 1; i < n - 1; i++)
        {
            for (int j = i; j <= n; j++)
            {
                if (i * i + j * j > n * n) continue;
                int sum = i * i + j * j;
                double result = Math.Pow(sum, 0.5);
                int num = (int)result;
                if (sum == num * num && num <= n) count++;
            }
        }
        return count * 2;
    }

    //1995.统计特殊四元组(简单, 枚举)
    // 给你一个 下标从 0 开始 的整数数组 nums ，返回满足下述条件的 不同 四元组 (a, b, c, d) 的 数目 ：
    // nums[a] + nums[b] + nums[c] == nums[d] ，且
    // a < b < c < d
    // 示例1：输入：nums = [1,2,3,6], 输出：1
    // 解释：满足要求的唯一一个四元组是 (0, 1, 2, 3) 因为 1 + 2 + 3 == 6
    // 示例2：输入：nums = [3,3,6,4,5], 输出：0
    // 解释：[3,3,6,4,5] 中不存在满足要求的四元组。
    // 示例3：输入：nums = [1,1,1,3,5], 输出：4
    // 解释：满足要求的 4 个四元组如下：
    // - (0, 1, 2, 3): 1 + 1 + 1 == 3
    // - (0, 1, 3, 4): 1 + 1 + 3 == 5
    // - (0, 2, 3, 4): 1 + 1 + 3 == 5
    // - (1, 2, 3, 4): 1 + 1 + 3 == 5
    public int CountQuadruplets(int[] nums)
    {
        int count = 0;
        for (int i = 0; i < nums.Length - 3; i++)
        {
            for (int j = i + 1; j < nums.Length - 2; j++)
            {
                for (int k = j + 1; k < nums.Length - 1; k++)
                {
                    for (int l = k + 1; l < nums.Length; l++)
                    {
                        if (nums[i] + nums[j] + nums[k] == nums[l]) count++;
                    }
                }
            }
        }
        return count;
    }

    //2094.找出 3 位偶数(简单, 枚举)
    // 给你一个整数数组 digits ，其中每个元素是一个数字（0 - 9）。数组中可能存在重复元素。
    // 你需要找出所有满足下述条件且互不相同的整数：
    // 该整数由 digits 中的三个元素按任意顺序依次连接组成。
    // 该整数不含前导零
    // 该整数是一个偶数
    // 例如，给定的 digits 是 [1, 2, 3] ，整数 132 和 312 满足上面列出的全部条件。
    // 将找出的所有互不相同的整数按递增顺序排列，并以数组形式返回。
    // 示例1：输入：digits = [2,1,3,0], 输出：[102,120,130,132,210,230,302,310,312,320]
    // 解释：
    // 所有满足题目条件的整数都在输出数组中列出。 
    // 注意，答案数组中不含有奇数或带前导零的整数。
    // 示例2：输入：digits = [2,2,8,8,2], 输出：[222,228,282,288,822,828,882]
    // 解释：
    // 同样的数字（0 - 9）在构造整数时可以重复多次，重复次数最多与其在 digits 中出现的次数一样。 
    // 在这个例子中，数字 8 在构造 288、828 和 882 时都重复了两次。
    // 示例3：输入：digits = [3,7,5], 输出：[]
    // 解释：
    // 使用给定的 digits 无法构造偶数。
    public int[] FindEvenNumbers(int[] digits)
    {  
        int length = digits.Length;
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < length; i++)
        {
            if (digits[i] % 2 == 0)
            {
                for (int j = 0; j < length; j++)
                {
                    if (j != i && digits[j] != 0)
                    {
                        for (int k = 0; k < length; k++)
                        {
                            if (k != j && k != i)
                            {
                                int sum = digits[j] * 100 + digits[k] * 10 + digits[i];
                                set.Add(sum);
                            }
                        }
                    }
                }
            }
        }
        int[] result = new int[set.Count];
        int count = 0;
        foreach (int num in set)
        {
            result[count] = num;
            count++;
        }
        Array.Sort(result);
        return result;
    }

    // 2259. 移除指定数字得到的最大结果(简单, 枚举)
    // 给你一个表示某个正整数的字符串 number 和一个字符 digit 。
    // 从 number 中恰好移除一个等于 digit 的字符后，找出并返回按十进制表示最大的结果字符串。
    // 生成的测试用例满足 digit 在 number 中出现至少一次。
    // 示例 1：输入：number = "123", digit = "3", 输出："12"
    // 解释："123" 中只有一个 '3' ，在移除 '3' 之后，结果为 "12" 。
    // 示例 2：输入：number = "1231", digit = "1", 输出："231"
    // 解释：可以移除第一个 '1' 得到 "231" 或者移除第二个 '1' 得到 "123" 。
    // 由于 231 > 123 ，返回 "231" 。
    // 示例 3：输入：number = "551", digit = "5", 输出："51"
    // 解释：可以从 "551" 中移除第一个或者第二个 '5' 。
    // 两种方案的结果都是 "51" 
    public string RemoveDigit(string number, char digit)
    {
        HashSet<string> set = new HashSet<string>();
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i].Equals(digit))
            {
                string str = number.Substring(0,i) + number.Substring(i + 1);
                set.Add(str);
            }
        }
        string num = "0";
        foreach (string str in set)
        {
            if (string.Compare(str, num) == 1) num = str;
        }
        return num;
    }

    // 459. 重复的子字符串(简单, 字符串匹配)
    // 给定一个非空的字符串 s ，检查是否可以通过由它的一个子串重复多次构成。
    // 示例 1:
    // 输入: s = "abab"
    // 输出: true
    // 解释: 可由子串 "ab" 重复两次构成。
    // 示例 2:
    // 输入: s = "aba"
    // 输出: false
    // 示例 3:
    // 输入: s = "abcabcabcabc"
    // 输出: true
    // 解释: 可由子串 "abc" 重复四次构成。 (或子串 "abcabc" 重复两次构成。)
    public bool RepeatedSubstringPattern(string s)
    {
        string str = "";
        int flag = 0;
        foreach(char ch in s)
        {
            str += ch;
            string[] strs = s.Split(str);
            foreach (string st in strs)
            {
                if (st != "") 
                {
                    flag = -1;
                    break;
                }
            }
            if (flag == 0 && str != s) return true;
            flag = 0;
        }
        return false;
    }

    // 796. 旋转字符串(简单, 字符串匹配)
    // 给定两个字符串, s 和 goal。如果在若干次旋转操作之后，s 能变成 goal ，那么返回 true 。
    // s 的 旋转操作 就是将 s 最左边的字符移动到最右边。 
    // 例如, 若 s = 'abcde'，在旋转一次之后结果就是'bcdea' 。
    // 示例 1:
    // 输入: s = "abcde", goal = "cdeab"
    // 输出: true
    // 示例 2:
    // 输入: s = "abcde", goal = "abced"
    // 输出: false
    public bool RotateString(string s, string goal)
    {
        if (s.Length != goal.Length) return false;
        if (s.Equals(goal)) return true;
        for (int i = 0; i < s.Length - 1; i++)
        {
            s = s.Substring(1) + s[0];
            if (s.Equals(goal)) return true;
        }
        return false;
    }

    // 1408. 数组中的字符串匹配(简单, 字符串匹配)
    // 给你一个字符串数组 words ，数组中的每个字符串都可以看作是一个单词。
    // 请你按 任意 顺序返回 words 中是其他单词的子字符串的所有单词。
    // 如果你可以删除 words[j] 最左侧和/或最右侧的若干字符得到 words[i] ，那么字符串 words[i] 就是 words[j] 的一个子字符串。
    // 示例 1：
    // 输入：words = ["mass","as","hero","superhero"]
    // 输出：["as","hero"]
    // 解释："as" 是 "mass" 的子字符串，"hero" 是 "superhero" 的子字符串。
    // ["hero","as"] 也是有效的答案。
    // 示例 2：
    // 输入：words = ["leetcode","et","code"]
    // 输出：["et","code"]
    // 解释："et" 和 "code" 都是 "leetcode" 的子字符串。
    // 示例 3：
    // 输入：words = ["blue","green","bu"]
    // 输出：[]
    public IList<string> StringMatching(string[] words)
    {
        HashSet<string> set = new HashSet<string>();
        foreach (string str in words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == str || str.Length > words[i].Length) continue;
                if (words[i].Contains(str)) set.Add(str);
            }
        }
        return set.ToList();
    }

    // 1455. 检查单词是否为句中其他单词的前缀(简单, 字符串匹配)
    // 给你一个字符串 sentence 作为句子并指定检索词为 searchWord ，其中句子由若干用 单个空格 分隔的单词组成。请你检查检索词 searchWord 是否为句子 sentence 中任意单词的前缀。
    // 如果 searchWord 是某一个单词的前缀，则返回句子 sentence 中该单词所对应的下标（下标从 1 开始）。如果 searchWord 是多个单词的前缀，则返回匹配的第一个单词的下标（最小下标）。如果 searchWord 不是任何单词的前缀，则返回 -1 。
    // 字符串 s 的 前缀 是 s 的任何前导连续子字符串。
    // 示例 1：
    // 输入：sentence = "i love eating burger", searchWord = "burg"
    // 输出：4
    // 解释："burg" 是 "burger" 的前缀，而 "burger" 是句子中第 4 个单词。
    // 示例 2：
    // 输入：sentence = "this problem is an easy problem", searchWord = "pro"
    // 输出：2
    // 解释："pro" 是 "problem" 的前缀，而 "problem" 是句子中第 2 个也是第 6 个单词，但是应该返回最小下标 2 。
    // 示例 3：
    // 输入：sentence = "i am tired", searchWord = "you"
    // 输出：-1
    // 解释："you" 不是句子中任何单词的前缀。
    public int IsPrefixOfWord(string sentence, string searchWord)
    {
        string[] strs = sentence.Split(" ");
        for (int i = 0; i < strs.Length; i++)
        {
            if (strs[i].StartsWith(searchWord)) return i + 1;
        }
        return -1;
    }

    // 1668. 最大重复子字符串(简单, 字符串匹配)
    // 给你一个字符串 sequence ，如果字符串 word 连续重复 k 次形成的字符串是 sequence 的一个子字符串，那么单词 word 的 重复值为 k 。单词 word 的 最大重复值 是单词 word 在 sequence 中最大的重复值。如果 word 不是 sequence 的子串，那么重复值 k 为 0 。
    // 给你一个字符串 sequence 和 word ，请你返回 最大重复值 k 。
    // 示例 1：
    // 输入：sequence = "ababc", word = "ab"
    // 输出：2
    // 解释："abab" 是 "ababc" 的子字符串。
    // 示例 2：
    // 输入：sequence = "ababc", word = "ba"
    // 输出：1
    // 解释："ba" 是 "ababc" 的子字符串，但 "baba" 不是 "ababc" 的子字符串。
    // 示例 3：
    // 输入：sequence = "ababc", word = "ac"
    // 输出：0
    // 解释："ac" 不是 "ababc" 的子字符串。
    public int MaxRepeating(string sequence, string word)
    {
        int count = 0;
        if (sequence.Contains(word))
        {
            count++;
            string str = word + word;
            while (sequence.Contains(str))
            {
                count++;
                str += word;
            }
        }
        return count;
    }

    // 561. 数组拆分(简单, 计数排序)
    // 给定长度为 2n 的整数数组 nums ，你的任务是将这些数分成 n 对, 例如 (a1, b1), (a2, b2), ..., (an, bn) ，使得从 1 到 n 的 min(ai, bi) 总和最大。
    // 返回该 最大总和 。
    // 示例 1：
    // 输入：nums = [1,4,3,2]
    // 输出：4
    // 解释：所有可能的分法（忽略元素顺序）为：
    // 1. (1, 4), (2, 3) -> min(1, 4) + min(2, 3) = 1 + 2 = 3
    // 2. (1, 3), (2, 4) -> min(1, 3) + min(2, 4) = 1 + 2 = 3
    // 3. (1, 2), (3, 4) -> min(1, 2) + min(3, 4) = 1 + 3 = 4
    // 所以最大总和为 4
    // 示例 2：
    // 输入：nums = [6,2,6,5,1,2]
    // 输出：9
    // 解释：最优的分法为 (2, 1), (2, 5), (6, 6). min(2, 1) + min(2, 5) + min(6, 6) = 1 + 2 + 6 = 9
    public int ArrayPairSum(int[] nums)
    {
        Array.Sort(nums);
        int sum = 0;
        for (int i = 0; i < nums.Length; i+=2)
        {
            sum += nums[i];
        }
        return sum;
    }

    // 1051. 高度检查器(简单, 计数排序)
    // 学校打算为全体学生拍一张年度纪念照。根据要求，学生需要按照 非递减 的高度顺序排成一行。
    // 排序后的高度情况用整数数组 expected 表示，其中 expected[i] 是预计排在这一行中第 i 位的学生的高度（下标从 0 开始）。
    // 给你一个整数数组 heights ，表示 当前学生站位 的高度情况。heights[i] 是这一行中第 i 位学生的高度（下标从 0 开始）。
    // 返回满足 heights[i] != expected[i] 的 下标数量 。
    // 示例：
    // 输入：heights = [1,1,4,2,1,3]
    // 输出：3 
    // 解释：
    // 高度：[1,1,4,2,1,3]
    // 预期：[1,1,1,2,3,4]
    // 下标 2 、4 、5 处的学生高度不匹配。
    // 示例 2：
    // 输入：heights = [5,1,2,3,4]
    // 输出：5
    // 解释：
    // 高度：[5,1,2,3,4]
    // 预期：[1,2,3,4,5]
    // 所有下标的对应学生高度都不匹配。
    // 示例 3：
    // 输入：heights = [1,2,3,4,5]
    // 输出：0
    // 解释：
    // 高度：[1,2,3,4,5]
    // 预期：[1,2,3,4,5]
    // 所有下标的对应学生高度都匹配。
    public int HeightChecker(int[] heights)
    {
        int[] rightheihts = new int[heights.Length];
        for (int i = 0; i < heights.Length; i++)
        {
            rightheihts[i] = heights[i];
        }
        Array.Sort(rightheihts);
        int count = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            if (rightheihts[i] != heights[i]) count++;
        }
        return count;
    }

    // 1122. 数组的相对排序(简单, 计数排序)
    // 给你两个数组，arr1 和 arr2，arr2 中的元素各不相同，arr2 中的每个元素都出现在 arr1 中。
    // 对 arr1 中的元素进行排序，使 arr1 中项的相对顺序和 arr2 中的相对顺序相同。未在 arr2 中出现过的元素需要按照升序放在 arr1 的末尾。
    // 示例 1：
    // 输入：arr1 = [2,3,1,3,2,4,6,7,9,2,19], arr2 = [2,1,4,3,9,6]
    // 输出：[2,2,2,1,4,3,3,9,6,7,19]
    // 示例  2:
    // 输入：arr1 = [28,6,22,8,44,17], arr2 = [22,28,8,6]
    // 输出：[22,28,8,6,17,44]
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        foreach (int num in arr2)
        {
            dictionary.Add(num, 0);
        }
        Array.Sort(arr1);
        foreach (int num in arr1)
        {
            if (!dictionary.TryAdd(num, 1)) dictionary[num]++;
        }
        int count = 0;
        for (int i = 0; i < dictionary.Count; i++)
        {
            var item = dictionary.ElementAt(i);
            for (int j = 0; j < item.Value; j++)
            {
                arr1[count] = item.Key;
                count++;
            }
        }
        return arr1;    
    }

    // 11. 盛最多水的容器(中等, 数组)
    // 给定一个长度为 n 的整数数组 height 。有 n 条垂线，第 i 条线的两个端点是 (i, 0) 和 (i, height[i]) 。
    // 找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。
    // 返回容器可以储存的最大水量。
    // 说明：你不能倾斜容器。
    // 示例1：
    // 输入：[1,8,6,2,5,4,8,3,7]
    // 输出：49 
    // 解释：图中垂直线代表输入数组 [1,8,6,2,5,4,8,3,7]。在此情况下，容器能够容纳水（表示为蓝色部分）的最大值为 49。
    // 示例 2：
    // 输入：height = [1,1]
    // 输出：1
    public int MaxArea(int[] height)
    {
        /* 可以计算出结果，但是当height数据过长时，超出时间限制
        int maxArea = 0;
        for (int i = 0; i < height.Length - 1; i++)
        {
            for (int j = i + 1; j < height.Length; j++)
            {
                int area = (height[i] < height[j] ? height[i] : height[j]) * (j - i);
                if (area > maxArea) maxArea = area;
            }
        }
        return maxArea;
        */
        // 双指针！！！！！！！
        int maxArea = 0;
        int i = 0;
        int j = height.Length - 1;
        while (i < j)
        {
            int area = (height[i] < height[j] ? height[i] : height[j]) * (j - i);
            if (area > maxArea) maxArea = area;
            if (height[i] < height[j]) i++;
            else j--;
        }
        return maxArea;

    }

    // 15. 三数之和(中等, 数组)
    // 给你一个整数数组 nums ，判断是否存在三元组 [nums[i], nums[j], nums[k]] 满足 i != j、i != k 且 j != k ，同时还满足 nums[i] + nums[j] + nums[k] == 0 。请
    // 你返回所有和为 0 且不重复的三元组。
    // 注意：答案中不可以包含重复的三元组。
    // 示例 1：
    // 输入：nums = [-1,0,1,2,-1,-4]
    // 输出：[[-1,-1,2],[-1,0,1]]
    // 解释：
    // nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0 。
    // nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0 。
    // nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0 。
    // 不同的三元组是 [-1,0,1] 和 [-1,-1,2] 。
    // 注意，输出的顺序和三元组的顺序并不重要。
    // 示例 2：
    // 输入：nums = [0,1,1]
    // 输出：[]
    // 解释：唯一可能的三元组和不为 0 。
    // 示例 3：
    // 输入：nums = [0,0,0]
    // 输出：[[0,0,0]]
    // 解释：唯一可能的三元组和为 0 。
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();
        HashSet<string> set = new HashSet<string>();
        int length = nums.Length;
        if (length < 3) return result;
        Array.Sort(nums);
        for (int i = 1; i < length - 1; i++)
        {
            int left = 0;
            int right = length - 1;
            while(left < i && right > i)
            {
                if (nums[i] + nums[left] + nums[right] == 0)
                {
                    string str = nums[left].ToString() + nums[i].ToString() + nums[right].ToString();
                    if (set.Add(str)) result.Add(new List<int> {nums[left], nums[i], nums[right]}); 
                    left++;                  
                }
                else if (nums[i] + nums[left] + nums[right] > 0)
                {
                    right--;
                    while(right > i && nums[right] == nums[right + 1]) right--;
                }
                else if (nums[i] + nums[left] + nums[right] < 0)
                {
                    left++;
                    while (left < i && nums[left] == nums[left - 1]) left++;
                }
                else {}
            }
        }
        return result;
    }

    // 16. 最接近的三数之和(中等, 数组)
    // 给你一个长度为 n 的整数数组 nums 和 一个目标值 target。请你从 nums 中选出三个整数，使它们的和与 target 最接近。
    // 返回这三个数的和。
    // 假定每组输入只存在恰好一个解。
    // 示例 1：
    // 输入：nums = [-1,2,1,-4], target = 1
    // 输出：2
    // 解释：与 target 最接近的和是 2 (-1 + 2 + 1 = 2) 。
    // 示例 2：
    // 输入：nums = [0,0,0], target = 1
    // 输出：0
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        int length = nums.Length;
        int sum = 0;
        int diff = 0;
        if (nums[0] + nums[1] + nums[2] >= target) return nums[0] + nums[1] + nums[2];
        diff = nums[0] + nums[1] + nums[2] - target;
        for (int i = 0; i < length - 2; i++)
        {
            for (int j = i + 1; j < length - 1; j++)
            {
                int k = j + 1;           
                do
                {
                    sum = nums[i] + nums[j] + nums[k];
                    if (Math.Abs(sum - target) == 0) return sum;
                    if (Math.Abs(sum - target) < Math.Abs(diff)) diff = sum - target;
                    k++;
                }while(k < length);
            }
        }
        return diff + target;
    }

    // 3. 无重复字符的最长子串(中等, 字符串)
    // 给定一个字符串 s ，请你找出其中不含有重复字符的 最长子串 的长度。
    // 示例 1:
    // 输入: s = "abcabcbb"
    // 输出: 3 
    // 解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
    // 示例 2:
    // 输入: s = "bbbbb"
    // 输出: 1
    // 解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
    // 示例 3:
    // 输入: s = "pwwkew"
    // 输出: 3
    // 解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
    // 请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> dictionary = new Dictionary<char, int>();
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (!dictionary.TryAdd(s[i], i))
            {
                count = count > dictionary.Count ? count : dictionary.Count;
                i = dictionary[s[i]] + 1;
                dictionary.Clear();
                dictionary.TryAdd(s[i], i);
            }
        }
        count = count > dictionary.Count ? count : dictionary.Count;
        return count;
    }

    // 5. 最长回文子串(中等, 字符串)
    // 给你一个字符串 s，找到 s 中最长的回文子串。
    // 如果字符串的反序与原始字符串相同，则该字符串称为回文字符串。
    // 示例 1：
    // 输入：s = "babad"
    // 输出："bab"
    // 解释："aba" 同样是符合题意的答案。
    // 示例 2：
    // 输入：s = "cbbd"
    // 输出："bb"
    public string LongestPalindrome(string s)
    {
        string result = s[0].ToString();
        if (s.Equals(new string(s.Reverse().ToArray()))) return s;
        for (int i = 0; i < s.Length; i++)
        {
            if (i + 1 <= s.Length - 1 && s[i] == s[i + 1])
            {
                int j = 0;
                while (i - j >= 0 && i + 1 + j < s.Length)
                {
                    string str = s.Substring(i - j, 2 + 2 * j);
                    if (str.Equals(new string(str.Reverse().ToArray())))
                    {
                        if (str.Length > result.Length) result = str;
                    }
                    j++;
                }
            }
            if (i + 2 <= s.Length - 1 && s[i] == s[i + 2])
            {
                int j = 0;
                while (i - j >= 0 && i + 2 + j < s.Length)
                {
                    string str = s.Substring(i - j, 3 + 2 * j);
                    if (str.Equals(new string(str.Reverse().ToArray())))
                    {
                        if (str.Length > result.Length) result = str;
                    }
                    j++;
                }
            }
        }
        return result;
    }

    // 寻找数组的中心索引 
    // 给你一个整数数组 nums ，请计算数组的 中心下标 。
    // 数组 中心下标 是数组的一个下标，其左侧所有元素相加的和等于右侧所有元素相加的和。
    // 如果中心下标位于数组最左端，那么左侧数之和视为 0 ，因为在下标的左侧不存在元素。这一点对于中心下标位于数组最右端同样适用。
    // 如果数组有多个中心下标，应该返回 最靠近左边 的那一个。如果数组不存在中心下标，返回 -1 。
    // 示例 1：
    // 输入：nums = [1, 7, 3, 6, 5, 6]
    // 输出：3
    // 解释：
    // 中心下标是 3 。
    // 左侧数之和 sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11 ，
    // 右侧数之和 sum = nums[4] + nums[5] = 5 + 6 = 11 ，二者相等。
    // 示例 2：
    // 输入：nums = [1, 2, 3]
    // 输出：-1
    // 解释：
    // 数组中不存在满足此条件的中心下标。
    // 示例 3：
    // 输入：nums = [2, 1, -1]
    // 输出：0
    // 解释：
    // 中心下标是 0 。
    // 左侧数之和 sum = 0 ，（下标 0 左侧不存在元素），
    // 右侧数之和 sum = nums[1] + nums[2] = 1 + -1 = 0 。
    public int PivotIndex(int[] nums) 
    {
        int sum = nums.Sum();

        int leftsum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum -= nums[i];
            if (i > 0) leftsum += nums[i - 1];
            if (leftsum == sum) return i;
        }
        return -1;
    }
    
    // 搜索插入位置
    // 给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
    // 请必须使用时间复杂度为 O(log n) 的算法。
    // 示例 1:
    // 输入: nums = [1,3,5,6], target = 5
    // 输出: 2
    // 示例 2:
    // 输入: nums = [1,3,5,6], target = 2
    // 输出: 1
    // 示例 3:
    // 输入: nums = [1,3,5,6], target = 7
    // 输出: 4  

    public int SearchInsert(int[] nums, int target) 
    {
        if (target > nums[nums.Length - 1]) return nums.Length;
        else if (target == nums[nums.Length - 1]) return nums.Length - 1;
        if (target <= nums[0]) return 0;

        int left = 0, right = nums.Length - 1, index = 0;
        while (index != (left + right) / 2)
        {
            index = (left + right) / 2;
            if (target == nums[index]) return index;
            if (target > nums[index]) left = index;
            if (target < nums[index]) right = index;
        }
        if (target > nums[index]) return index + 1;
        if (target < nums[index]) return index;
        return 0;
    }

    // 56.合并区间(中等)
    // 以数组 intervals 表示若干个区间的集合，其中单个区间为 intervals[i] = [starti, endi] 。请你合并所有重叠的区间，并返回 一个不重叠的区间数组，该数组需恰好覆盖输入中的所有区间 。
    // 示例 1：
    // 输入：intervals = [[1,3],[2,6],[8,10],[15,18]]
    // 输出：[[1,6],[8,10],[15,18]]
    // 解释：区间 [1,3] 和 [2,6] 重叠, 将它们合并为 [1,6].
    // 示例 2：
    // 输入：intervals = [[1,4],[4,5]]
    // 输出：[[1,5]]
    // 解释：区间 [1,4] 和 [4,5] 可被视为重叠区间。
    public int[][] Merge(int[][] intervals) 
    {
        //先对所有的区间按区间起始点进行排序
        int length = intervals.GetLength(0);
        for (int i = 0; i < length - 1; i++)
        {
            for (int j = i; j < length; j++)
            {
                if (intervals[i][0] > intervals[j][0])
                {
                    int[] temp = intervals[j];
                    intervals[j] = intervals[i];
                    intervals[i] = temp;
                }
            }
        }
        //区间判断
        List<int[]> areas = new List<int[]>();
        int[] area = new int[2];
        area = intervals[0];
        for (int i = 1; i < length; i++)
        {
            if (area[1] < intervals[i][0]) 
            {
                areas.Add(area);
                area = intervals[i];
                continue;
            }
            else if (area[1] < intervals[i][1])
            {
                area[1] = intervals[i][1];
            }
        }
        areas.Add(area);

        int[][] result = new int[areas.Count][];
        for (int i = 0; i < areas.Count; i++)
        {
            result[i] = areas[i];
        }
        return result;
    }

    //777.宝石与石头 (简单)
    // 给你一个字符串 jewels 代表石头中宝石的类型，另有一个字符串 stones 代表你拥有的石头。 stones 中每个字符代表了一种你拥有的石头的类型，你想知道你拥有的石头中有多少是宝石。
    // 字母区分大小写，因此 "a" 和 "A" 是不同类型的石头。 
    // 示例 1：
    // 输入：jewels = "aA", stones = "aAAbbbb"
    // 输出：3
    // 示例 2：
    // 输入：jewels = "z", stones = "ZZ"
    // 输出：0
    public int NumJewelsInStones(string jewels, string stones) 
    {
        int count = 0;
        foreach (char ch in stones)
        {
            if (jewels.Contains(ch)) count++;
        }
        return count;
    }

    // 2500. 删除每行中的最大值
    // 给你一个 m x n 大小的矩阵 grid ，由若干正整数组成。
    // 执行下述操作，直到 grid 变为空矩阵：
    // 从每一行删除值最大的元素。如果存在多个这样的值，删除其中任何一个。
    // 将删除元素中的最大值与答案相加。
    // 注意 每执行一次操作，矩阵中列的数据就会减 1 。
    // 返回执行上述操作后的答案。
    // 示例 1：
    // 输入：grid = [[1,2,4],[3,3,1]]
    // 输出：8
    // 解释：上图展示在每一步中需要移除的值。
    // 在第一步操作中，从第一行删除 4 ，从第二行删除 3（注意，有两个单元格中的值为 3 ，我们可以删除任一）。在答案上加 4 。
    // 在第二步操作中，从第一行删除 2 ，从第二行删除 3 。在答案上加 3 。
    // 在第三步操作中，从第一行删除 1 ，从第二行删除 1 。在答案上加 1 。
    // 最终，答案 = 4 + 3 + 1 = 8 。
    // 示例 2：
    // 输入：grid = [[10]]
    // 输出：10
    // 解释：上图展示在每一步中需要移除的值。
    // 在第一步操作中，从第一行删除 10 。在答案上加 10 。
    // 最终，答案 = 10 。
    public int DeleteGreatestValue(int[][] grid) 
    {
        int row = grid.GetLength(0);
        int col = grid[0].Length;
        int sum = 0;
        for (int i = 0; i < row; i++)
        {
            Array.Sort(grid[i]);
        }
        for (int i = 0; i < col; i++)
        {
            int max = 0;
            for (int j = 0; j < row; j++)
            {
                if (grid[j][i] > max) max = grid[j][i];
            }
            sum += max;
        }
        return sum;
    }

    // 822. 翻转卡片游戏
    // 在桌子上有 N 张卡片，每张卡片的正面和背面都写着一个正数（正面与背面上的数有可能不一样）。
    // 我们可以先翻转任意张卡片，然后选择其中一张卡片。
    // 如果选中的那张卡片背面的数字 X 与任意一张卡片的正面的数字都不同，那么这个数字是我们想要的数字。
    // 哪个数是这些想要的数字中最小的数（找到这些数中的最小值）呢？如果没有一个数字符合要求的，输出 0。
    // 其中, fronts[i] 和 backs[i] 分别代表第 i 张卡片的正面和背面的数字。
    // 如果我们通过翻转卡片来交换正面与背面上的数，那么当初在正面的数就变成背面的数，背面的数就变成正面的数。
    // 示例：
    // 输入：fronts = [1,2,4,4,7], backs = [1,3,4,1,3]
    // 输出：2
    // 解释：假设我们翻转第二张卡片，那么在正面的数变成了 [1,3,4,4,7] ， 背面的数变成了 [1,2,4,1,3]。
    // 接着我们选择第二张卡片，因为现在该卡片的背面的数是 2，2 与任意卡片上正面的数都不同，所以 2 就是我们想要的数字。
    public int Flipgame(int[] fronts, int[] backs) 
    {
        //思路：找到只出现一次的数，并排序
        //用 dictionary 把次数与数据都存入
        Dictionary<int,int> nums = new Dictionary<int, int>();
        int min = 0;
        for(int i = 0; i < fronts.Length; i++)
        {
            if (fronts[i] != backs[i])
            {
                nums.TryAdd(fronts[i], 1);
                nums.TryAdd(backs[i], 1);
            }
            else 
            {
                if (nums.TryGetValue(fronts[i], out int count)) nums[fronts[i]]++;
                else nums.TryAdd(fronts[i],2);
            } 
        }

        min = 0;
        foreach(KeyValuePair<int, int> kvp in nums)
        {
            if (kvp.Value == 1 && (min == 0 || min > kvp.Key)) min = kvp.Key;
        }
        return min;
    }

    // 48.旋转矩阵
    // 给你一幅由 N × N 矩阵表示的图像，其中每个像素的大小为 4 字节。请你设计一种算法，将图像旋转 90 度。
    // 不占用额外内存空间能否做到？
    // 示例 1:
    // 给定 matrix = 
    // [
    //   [1,2,3],
    //   [4,5,6],
    //   [7,8,9]
    // ],
    // 原地旋转输入矩阵，使其变为:
    // [
    //   [7,4,1],
    //   [8,5,2],
    //   [9,6,3]
    // ]
    // 示例 2:
    // 给定 matrix =
    // [
    //   [ 5, 1, 9,11],
    //   [ 2, 4, 8,10],
    //   [13, 3, 6, 7],
    //   [15,14,12,16]
    // ],   
    // 原地旋转输入矩阵，使其变为:
    // [
    //   [15,13, 2, 5], 
    //   [14, 3, 4, 1],
    //   [12, 6, 8, 9],
    //   [16, 7,10,11]
    // ]
    public void Rotate(int[][] matrix)
    {
        if (matrix.GetLength(0) == 1) return;
        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = i; j <= matrix.GetLength(0) - 1 - i; j++)
            {
                matrix[i][j] = matrix[i][j] + matrix[j][matrix.GetLength(0) - i - 1] + matrix[matrix.GetLength(0) - i - 1][matrix.GetLength(0) - j - 1] + matrix[matrix.GetLength(0) - j - 1][i];
                matrix[j][matrix.GetLength(0) - i - 1] = matrix[i][j] - matrix[j][matrix.GetLength(0) - i - 1] - matrix[matrix.GetLength(0) - i - 1][matrix.GetLength(0) - j - 1] - matrix[matrix.GetLength(0) - j - 1][i];
                matrix[matrix.GetLength(0) - i - 1][matrix.GetLength(0) - j - 1] = matrix[i][j] - matrix[j][matrix.GetLength(0) - i - 1] - matrix[matrix.GetLength(0) - i - 1][matrix.GetLength(0) - j - 1] - matrix[matrix.GetLength(0) - j - 1][i];
                matrix[matrix.GetLength(0) - j - 1][i] = matrix[i][j] - matrix[j][matrix.GetLength(0) - i - 1] - matrix[matrix.GetLength(0) - i - 1][matrix.GetLength(0) - j - 1] - matrix[matrix.GetLength(0) - j - 1][i];
                matrix[i][j] = matrix[i][j] - matrix[j][matrix.GetLength(0) - i - 1] - matrix[matrix.GetLength(0) - i - 1][matrix.GetLength(0) - j - 1] - matrix[matrix.GetLength(0) - j - 1][i];
            }
            
        }
    }
    // 617. 合并二叉树
    // 给你两棵二叉树： root1 和 root2 。
    // 想象一下，当你将其中一棵覆盖到另一棵之上时，两棵树上的一些节点将会重叠（而另一些不会）。你需要将这两棵树合并成一棵新二叉树。合并的规则是：如果两个节点重叠，那么将这两个节点的值相加作为合并后节点的新值；否则，不为 null 的节点将直接作为新二叉树的节点。
    // 返回合并后的二叉树。
    // 注意: 合并过程必须从两个树的根节点开始。
    // 示例 1：
    // 输入：root1 = [1,3,2,5], root2 = [2,1,3,null,4,null,7]
    // 输出：[3,4,5,5,4,null,7]
    // 示例 2：
    // 输入：root1 = [1], root2 = [1,2]
    // 输出：[2,2]
    // public TreeNode MergeTrees(TreeNode root1, TreeNode root2) 
    // {
    // }

    // 6. N 字形变换
    // 将一个给定字符串 s 根据给定的行数numRows，以从上往下、从左到右进行 Z 字形排列。
    // 比如输入字符串为 "PAYPALISHIRING" 行数为 3 时，排列如下：
    // P   A   H   N
    // A P L S I I G
    // Y   I   R
    // 之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："PAHNAPLSIIGYIR"。
    // 请你实现这个将字符串进行指定行数变换的函数：
    // string convert(string s, int numRows);
    // 示例 1：
    // 输入：s = "PAYPALISHIRING", numRows = 3
    // 输出："PAHNAPLSIIGYIR"
    // 示例 2：
    // 输入：s = "PAYPALISHIRING", numRows = 4
    // 输出："PINALSIGYAHRPI"
    // 解释：
    // P     I    N
    // A   L S  I G
    // Y A   H R
    // P     I
    // 示例 3：
    // 输入：s = "A", numRows = 1
    // 输出："A"
    public string Convert(string s, int numRows)
    {
        string str = "";
        int length = numRows * 2 - 2;
        int count = s.Length / length;
        if (s.Length % length != 0) count++;//一共有几组

        for (int i = 0; i < numRows; i++)
        {
            
        }
        return str;
    }

    
}