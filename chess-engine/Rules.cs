using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_engine
{
    public class Rules
    {
		public static int[][][][] PawnMoves = new[]{
			new[]
			{  // white
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//0
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//1
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//2
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//3
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//4
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//5
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//6
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//7
				new[]{ new[] { 16,24 }, new[] { 17 } },				//8
				new[]{ new[] { 17,25 }, new[] { 16,18 } },			//9
				new[]{ new[] { 18,26 }, new[] { 17,19 } },			//10
				new[]{ new[] { 19,27 }, new[] { 18,20 } },			//11
				new[]{ new[] { 20,28 }, new[] { 19,21 } },			//12
				new[]{ new[] { 21,29 }, new[] { 20,22 } },			//13
				new[]{ new[] { 22,30 }, new[] { 21,23 } },			//14
				new[]{ new[] { 23,31 }, new[] { 22 } },				//15
				new[]{ new[] { 24 }, new[] { 25 } },				//16
				new[]{ new[] { 25 }, new[] { 24,26 } },				//17
				new[]{ new[] { 26 }, new[] { 25,27 } },				//18
				new[]{ new[] { 27 }, new[] { 26,28 } },				//19
				new[]{ new[] { 28 }, new[] { 27,29 } },				//20
				new[]{ new[] { 29 }, new[] { 28,30 } },				//21
				new[]{ new[] { 30 }, new[] { 29,31 } },				//22
				new[]{ new[] { 31 }, new[] { 30 } },				//23
				new[]{ new[] { 32 }, new[] { 33 } },				//24
				new[]{ new[] { 33 }, new[] { 32,34 } },				//25
				new[]{ new[] { 34 }, new[] { 33,35 } },				//26
				new[]{ new[] { 35 }, new[] { 34,36 } },				//27
				new[]{ new[] { 36 }, new[] { 35,37 } },				//28
				new[]{ new[] { 37 }, new[] { 36,38 } },				//29
				new[]{ new[] { 38 }, new[] { 37,39 } },				//30
				new[]{ new[] { 39 }, new[] { 38 } },				//31
				new[]{ new[] { 40 }, new[] { 41 } },				//32
				new[]{ new[] { 41 }, new[] { 40,42 } },				//33
				new[]{ new[] { 42 }, new[] { 41,43 } },				//34
				new[]{ new[] { 43 }, new[] { 42,44 } },				//35
				new[]{ new[] { 44 }, new[] { 43,45 } },				//36
				new[]{ new[] { 45 }, new[] { 44,46 } },				//37
				new[]{ new[] { 46 }, new[] { 45,47 } },				//38
				new[]{ new[] { 47 }, new[] { 46 } },				//39
				new[]{ new[] { 48 }, new[] { 49 } },				//40
				new[]{ new[] { 49 }, new[] { 48,50 } },				//41
				new[]{ new[] { 50 }, new[] { 49,51 } },				//42
				new[]{ new[] { 51 }, new[] { 50,52 } },				//43
				new[]{ new[] { 52 }, new[] { 51,53 } },				//44
				new[]{ new[] { 53 }, new[] { 52,54 } },				//45
				new[]{ new[] { 54 }, new[] { 53,55 } },				//46
				new[]{ new[] { 55 }, new[] { 54 } },				//47
				new[]{ new[] { 56 }, new[] { 57 } },				//48
				new[]{ new[] { 57 }, new[] { 56,58 } },				//49
				new[]{ new[] { 58 }, new[] { 57,59 } },				//50
				new[]{ new[] { 59 }, new[] { 58,60 } },				//51
				new[]{ new[] { 60 }, new[] { 59,61 } },				//52
				new[]{ new[] { 61 }, new[] { 60,62 } },				//53
				new[]{ new[] { 62 }, new[] { 61,63 } },				//54
				new[]{ new[] { 63 }, new[] { 62 } },				//55
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//56
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//57
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//58
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//59
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//60
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//61
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//62
				new[]{ Array.Empty<int>(), Array.Empty<int>() }		//63
			},
			new[]
			{  // black
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//0
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//1
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//2
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//3
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//4
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//5
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//6
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//7
				new[]{ new[] { 0 }, new[] { 1 } },					//8
				new[]{ new[] { 1 }, new[] { 2,0 } },				//9
				new[]{ new[] { 2 }, new[] { 3,1 } },				//10
				new[]{ new[] { 3 }, new[] { 4,2 } },				//11
				new[]{ new[] { 4 }, new[] { 5,3 } },				//12
				new[]{ new[] { 5 }, new[] { 6,4 } },				//13
				new[]{ new[] { 6 }, new[] { 7,5 } },				//14
				new[]{ new[] { 7 }, new[] { 6 } },					//15
				new[]{ new[] { 8 }, new[] { 9 } },					//16
				new[]{ new[] { 9 }, new[] { 10,8 } },				//17
				new[]{ new[] { 10 }, new[] { 11,9 } },				//18
				new[]{ new[] { 11 }, new[] { 12,10 } },				//19
				new[]{ new[] { 12 }, new[] { 13,11 } },				//20
				new[]{ new[] { 13 }, new[] { 14,12 } },				//21
				new[]{ new[] { 14 }, new[] { 15,13 } },				//22
				new[]{ new[] { 15 }, new[] { 14 } },				//23
				new[]{ new[] { 16 }, new[] { 17 } },				//24
				new[]{ new[] { 17 }, new[] { 18,16 } },				//25
				new[]{ new[] { 18 }, new[] { 19,17 } },				//26
				new[]{ new[] { 19 }, new[] { 20,18 } },				//27
				new[]{ new[] { 20 }, new[] { 21,19 } },				//28
				new[]{ new[] { 21 }, new[] { 22,20 } },				//29
				new[]{ new[] { 22 }, new[] { 23,21 } },				//30
				new[]{ new[] { 23 }, new[] { 22 } },				//31
				new[]{ new[] { 24 }, new[] { 25 } },				//32
				new[]{ new[] { 25 }, new[] { 26,24 } },				//33
				new[]{ new[] { 26 }, new[] { 27,25 } },				//34
				new[]{ new[] { 27 }, new[] { 28,26 } },				//35
				new[]{ new[] { 28 }, new[] { 29,27 } },				//36
				new[]{ new[] { 29 }, new[] { 30,28 } },				//37
				new[]{ new[] { 30 }, new[] { 31,29 } },				//38
				new[]{ new[] { 31 }, new[] { 30 } },				//39
				new[]{ new[] { 32 }, new[] { 33 } },				//40
				new[]{ new[] { 33 }, new[] { 34,32 } },				//41
				new[]{ new[] { 34 }, new[] { 35,33 } },				//42
				new[]{ new[] { 35 }, new[] { 36,34 } },				//43
				new[]{ new[] { 36 }, new[] { 37,35 } },				//44
				new[]{ new[] { 37 }, new[] { 38,36 } },				//45
				new[]{ new[] { 38 }, new[] { 39,37 } },				//46
				new[]{ new[] { 39 }, new[] { 38 } },				//47
				new[]{ new[] { 40,32 }, new[] { 41 } },				//48
				new[]{ new[] { 41,33 }, new[] { 42,40 } },			//49
				new[]{ new[] { 42,34 }, new[] { 43,41 } },			//50
				new[]{ new[] { 43,35 }, new[] { 44,42 } },			//51
				new[]{ new[] { 44,36 }, new[] { 45,43 } },			//52
				new[]{ new[] { 45,37 }, new[] { 46,44 } },			//53
				new[]{ new[] { 46,38 }, new[] { 47,45 } },			//54
				new[]{ new[] { 47,39 }, new[] { 46 } },				//55
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//56
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//57
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//58
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//59
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//60
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//61
				new[]{ Array.Empty<int>(), Array.Empty<int>() },	//62
				new[]{ Array.Empty<int>(), Array.Empty<int>() }		//63
			}
		};

	}
}
