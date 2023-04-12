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
    //412.Fizz Buzz(简单，模拟)
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
}