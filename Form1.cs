using System.Collections;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace INA_Z2
{
	public partial class Form1 : Form
	{
		private readonly Random random = new Random();

		public Form1()
		{
			InitializeComponent();
			SetDefaultValues();
		}

		private void SetDefaultValues()
		{
			this.textBox1.Text = "-4";
			this.textBox2.Text = "12";
			this.comboBox1.SelectedIndex = 2;
			this.textBox4.Text = "10";
			this.textBox3.Text = "0,7";
			this.textBox5.Text = "0,002";
			this.comboBox2.SelectedIndex = 0;
		}

		public int GetLValue(int a, int b, float d)
		{
			return (int)Math.Ceiling(Math.Log2(((b - a) / d) + 1));
		}

		public string XIntToXBin(int num, int l)
		{
			string binary = Convert.ToString(num, 2);

			int i = 0;
			string tmp = string.Empty;
			while (l - binary.Length - i > 0)
			{
				tmp += "0";
				++i;
			}

			binary = tmp + binary;

			return binary;
		}

		public int XRealToXInt(int a, int b, double x_real, int l)
		{
			int result = (int)Math.Floor(1.0 / (b - a) * (x_real - a) * (Math.Pow(2, l) - 1));
			return result;
		}

		public int XBinToXInt(long x_longBin)
		{
			long xlongBin = x_longBin;
			long dec_val = 0;

			int base1 = 1;

			while (xlongBin > 0)
			{
				long last_digit = xlongBin % 10;
				xlongBin /= 10;

				dec_val += last_digit * base1;
				base1 = base1 * 2;
			}

			return (int)dec_val;
		}

		/// <summary>
		/// Converts binary number (in string) to decimal (int)
		/// </summary>
		/// <param name="xbin"></param>
		/// <returns></returns>
		public int XBinToXInt(string xbin)
		{
			return Convert.ToInt32(xbin, 2);
		}

		public float XIntToXReal(int a, int b, int x_int, int l, float d)
		{
			float result = (float)(x_int * (b - a)) / (float)(Math.Pow(2, l) - 1) + a;
			result = float.Parse(result.ToString($"f{GetPrecInNumber(d)}"));
			return result;
		}

		/// <summary>
		/// Counts f(x) value. Defines the function.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public double CountFxValue(double x)
		{
			//double fx = -Math.Pow(x, 3) + 2 * Math.Pow(x, 2) + x - 2;
			double fx = x % 1 * (Math.Cos(20 * Math.PI * x) - Math.Sin(x));
			return fx;
		}

		public decimal CountGxValue(double fxValue, double fmin, double fmax, float d)
		{
			if (comboBox2.SelectedIndex == 0)
			{
				decimal gx = (decimal)fxValue - (decimal)fmin + (decimal)d;
				return gx;
			}
			else
				throw new InvalidDataException();
		}

		public float GetRandomNumberWithPrecision(int min, int max, int prec)
		{
			float randomNumber = (float)(random.NextDouble() * (max - min) + min);
			decimal decimalNumber = Math.Round(Convert.ToDecimal(randomNumber), prec);
			float number = (float)decimalNumber;
			return number;
		}

		public float GetRandomFloatNumber(int min, int max)
		{
			float randomNumber = (float)(random.NextDouble() * (max - min) + min);
			return randomNumber;
		}

		public double GetRandomIntNumber(int min, int max)
		{
			float randomNumber = (float)(random.NextDouble() * (max - min) + min);
			decimal decimalNumber = Math.Round(Convert.ToDecimal(randomNumber));
			float number = (float)decimalNumber;
			return number;
		}

		public int GetPrecInNumber(float d)
		{
			switch (d)
			{
				case 0.1f:
					return 1;
				case 0.01f:
					return 2;
				case 0.001f:
					return 3;
				case 0.0001f:
					return 4;
				default:
					throw new InvalidDataException();
			}
		}

		public void AssignInputValues(out int a, out int b, out int n, out float d, out float p_k, out float p_m)
		{
			int.TryParse(textBox1.Text, out a);
			int.TryParse(textBox2.Text, out b);
			int.TryParse(textBox4.Text, out n);
			float.TryParse(comboBox1.SelectedItem.ToString(), out d);
			float.TryParse(textBox3.Text, out p_k);
			float.TryParse(textBox5.Text, out p_m);
		}

		public double[] FillFirstTwoColumnsAndXrealArray(int a, int b, int n, int prec)
		{
			double[] xrealArray = new double[n];
			for (int i = 0; i < n; ++i)
			{
				float xreal = GetRandomNumberWithPrecision(a, b, prec);

				xrealArray[i] = xreal;

				dataGridView1.Rows.Add(i + 1, xreal);
			}
			return xrealArray;
		}

		public double[] FillFxColumnAndFxValuesArray(ReadOnlySpan<double> xrealArray)
		{
			int n = xrealArray.Length;

			double[] fxValuesArray = new double[n];
			for (int i = 0; i < n; ++i)
			{
				double xreal = xrealArray[i];
				double fxValue = CountFxValue(xreal);

				fxValuesArray[i] = fxValue;

				dataGridView1[2, i].Value = fxValue;
			}
			return fxValuesArray;
		}

		public double[] FillGxColumnAndGxValuesArray(float d, double[] fxValuesArray)
		{
			int n = fxValuesArray.Length;

			double gxValue;
			double[] gxValuesArray = new double[n];

			for (int i = 0; i < n; ++i)
			{
				gxValue = (double)CountGxValue(fxValuesArray[i], fxValuesArray.Min(), fxValuesArray.Max(), d);

				gxValuesArray[i] = gxValue;

				dataGridView1[3, i].Value = gxValue;
			}

			return gxValuesArray;
		}

		public double[] FillP_iColumnAndPArray(double[] gxValuesArray)
		{
			int n = gxValuesArray.Length;

			double gxSum = gxValuesArray.Sum();

			double[] pArray = new double[n];

			for (int i = 0; i < n; ++i)
			{
				double p = gxValuesArray[i] / gxSum;

				pArray[i] = p;

				dataGridView1[4, i].Value = p;
			}

			return pArray;
		}

		public double[] FillQ_iColumnAndQArray(ReadOnlySpan<double> pArray)
		{
			int n = pArray.Length;
			double[] qArray = new double[n];

			double q = 0;

			for (int i = 0; i < n; ++i)
			{
				q += pArray[i];
				qArray[i] = q;

				dataGridView1[5, i].Value = q;
			}

			return qArray;
		}

		public double[] FillRColumnAndRArray(int n)
		{
			double[] rArray = new double[n];
			double r;

			for (int i = 0; i < n; ++i)
			{
				r = random.NextDouble();
				rArray[i] = r;

				dataGridView1[6, i].Value = r;
			}

			return rArray;
		}

		public double[] FillSelectedColumnAndSelectedArray(ReadOnlySpan<double> xrealArray, ReadOnlySpan<double> qArray, ReadOnlySpan<double> rArray)
		{
			int n = xrealArray.Length;
			double[] selected = new double[n];

			for (int rIterator = 0; rIterator < n; ++rIterator)
			{
				for (int qIterator = 0; qIterator < n; ++qIterator)
				{
					double qValue = qArray[qIterator];
					double rValue = rArray[rIterator];

					if (qIterator == 0)
					{
						if (qValue >= rValue)
						{
							selected[rIterator] = xrealArray[qIterator];
							dataGridView1[7, rIterator].Value = selected[rIterator];
						}
					}

					else
					{
						double lastQValue = qArray[qIterator - 1];

						if (qValue >= rValue && lastQValue < rValue)
						{
							selected[rIterator] = xrealArray[qIterator];
							dataGridView1[7, rIterator].Value = selected[rIterator];
						}
					}
				}
			}
			return selected;
		}

		public string[] FillXbinColumnAndXbinArray(int a, int b, int l, ReadOnlySpan<double> selected)
		{
			int n = selected.Length;
			string[] xbinArray = new string[n];

			for (int i = 0; i < n; ++i)
			{
				xbinArray[i] = XIntToXBin(XRealToXInt(a, b, selected[i], l), l);

				dataGridView1[8, i].Value = xbinArray[i];
			}

			return xbinArray;
		}

		public string[] FillParentsColumnAndParentsArray(int n, double p_k, ReadOnlySpan<string> xbinArray)
		{
			string[] parents = new string[n];
			do
			{
				for (int i = 0; i < n; ++i)
				{
					if (string.IsNullOrEmpty(parents[i]))
					{
						double tmpR = random.NextDouble();
						if (tmpR <= p_k)
						{
							dataGridView1[9, i].Value = xbinArray[i];
							parents[i] = xbinArray[i];
						}
					}
				}
			} while (parents.Count(parent => parent != string.Empty) == 1);

			return parents;
		}

		public int CountParents(int n, ReadOnlySpan<string> parents)
		{
			int parentCounter = 0;
			for (int i = 0; i < n; ++i)
			{
				if (!string.IsNullOrEmpty(parents[i]))
				{
					++parentCounter;
				}
			}

			return parentCounter;
		}

		public (string[], int[]) FilterParentsAndTheirIndexes(int parentCounter, ReadOnlySpan<string> parents)
		{
			string[] filteredParents = new string[parentCounter];
			int[] indexesOfFiltered = new int[parentCounter];
			for (int i = 0, j = 0; j < filteredParents.Length; ++i)
			{
				if (!string.IsNullOrEmpty(parents[i]))
				{
					filteredParents[j] = parents[i];
					indexesOfFiltered[j] = i;
					++j;
				}
			}

			return (filteredParents, indexesOfFiltered);
		}

		public List<Tuple<string, string, int>> PerformPairingAndAddToListWithRandomNumber(int l, ReadOnlySpan<string> filteredParents)
		{
			List<Tuple<string, string, int>> pairs = new List<Tuple<string, string, int>>();
			for (int i = 0; i < filteredParents.Length - 1; i += 2)
			{
				int randomNum = random.Next(0, l - 2);
				Tuple<string, string, int> pair = new Tuple<string, string, int>(filteredParents[i], filteredParents[i + 1], randomNum);
				pairs.Add(pair);
			}
			if (filteredParents.Length % 2 == 1)
			{
				pairs.Add(new Tuple<string, string, int>(filteredParents[filteredParents.Length - 1], filteredParents[0], random.Next(0, l - 2)));
			}

			return pairs;
		}

		public void FillP_cColumn(ReadOnlySpan<string> parents, List<Tuple<string, string, int>> pairs)
		{
			int pom = 0;
			for (int z = pom; z < parents.Length; ++z)
			{
				if (dataGridView1[9, z].Value != null)
				{
					int pom2 = 0;
					for (int pairIterator = pom2; pairIterator < pairs.Count; ++pairIterator)
					{
						if (dataGridView1[9, z].Value == pairs[pairIterator].Item1 || dataGridView1[9, z].Value == pairs[pairIterator].Item2)
						{
							dataGridView1[10, z].Value = pairs[pairIterator].Item3;
							break;
						}
						++pom2;
					}
				}
				++pom;
			}
		}

		public List<string> PerformCrossingAndReturnOnlyChildren(List<Tuple<string, string, int>> pairs)
		{
			List<string> children = new List<string>();
			foreach (var pair in pairs)
			{
				string start1, start2, ending1, ending2;
				string child1, child2;

				int length1 = pair.Item1.Length;
				int length2 = pair.Item2.Length;
				int cutPoint = Convert.ToInt32(pair.Item3);

				int endDistance1 = length1 - cutPoint;
				int endDistance2 = length2 - cutPoint;

				start1 = pair.Item1.Substring(0, length1 - endDistance1);
				start2 = pair.Item2.Substring(0, length2 - endDistance2);
				ending1 = pair.Item1.Substring(length1 - endDistance1);
				ending2 = pair.Item2.Substring(length2 - endDistance2);

				child1 = start1 + ending2;
				child2 = start2 + ending1;

				children.Add(child1);
				children.Add(child2);
			}

			return children;
		}

		public string[] SaveChildrenToPostCrossingArray(int n, List<string> children, ReadOnlySpan<int> indexesOfFiltered)
		{
			string[] earlyCrossing = new string[n];

			int i = 0;
			foreach (int index in indexesOfFiltered)
			{
				earlyCrossing[index] = children[i];
				++i;
			}

			return earlyCrossing;
		}

		public void FillEmptyFieldsWithRelevantXbin(ReadOnlySpan<string> xbinArr, string[] allPostCrossing)
		{
			int i = 0;
			foreach (string xBin in xbinArr)
			{
				if (string.IsNullOrEmpty(allPostCrossing[i]))
				{
					allPostCrossing[i] = xBin;
				}
				++i;
			}
		}

		public string[] HandlePostCrossingArray(int n, List<string> children, ReadOnlySpan<int> indexesOfFiltered, ReadOnlySpan<string> xbinArr)
		{
			string[] allPostCrossing = new string[n];

			//save every child to the array
			allPostCrossing = SaveChildrenToPostCrossingArray(n, children, indexesOfFiltered);

			//save every xbin in case a field in array "post crossing" is empty
			//fill every empty field in the "crossing" column with xbin (according to table)
			//MODIFIES array without returning
			FillEmptyFieldsWithRelevantXbin(xbinArr, allPostCrossing);

			for (int i = 0; i < n; ++i)
			{
				dataGridView1[11, i].Value = allPostCrossing[i];
			}

			return allPostCrossing;
		}

		public int[,] FillMutatedIndexesArrayWithMinus1s(int n, int l)
		{
			int[,] mutatedIndexes = new int[n, l];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < l; j++)
				{
					mutatedIndexes[i, j] = -1;
				}
			}

			return mutatedIndexes;
		}

		public void FillMutatedXrealAndNewFxColumns(int a, int b, int n, int l, string[] postCrossingCopy, float d)
		{
			//write 2 last columns
			for (int i = 0; i < n; ++i)
			{
				dataGridView1[14, i].Value = XIntToXReal(a, b, XBinToXInt(postCrossingCopy[i]), l, d);
				dataGridView1[15, i].Value = CountFxValue(Convert.ToDouble(dataGridView1[14, i].Value));
			}
		}

		public void Fill2DArrayWithMutatedBitsIndexes(int n, int l, float p_m, ReadOnlySpan<string> allPostCrossing, int[,] mutatedIndexes)
		{
			for (int i = 0; i < n; ++i)
			{
				if (dataGridView1[11, i].Value != null)
				{
					string postCrossingString = allPostCrossing[i];

					int j = 0;
					foreach (char sign in postCrossingString)
					{
						double randomVal = GetRandomFloatNumber(0, 1);

						if (randomVal <= p_m)
						{
							if (dataGridView1[12, i].Value != null)
							{
								dataGridView1[12, i].Value += ", ";
							}
							dataGridView1[12, i].Value += $"{j}";
							mutatedIndexes[i, j] = j;
						}
						++j;
					}
				}
			}
		}

		public int[,] HandleMutatedBitsArray(int n, int l, float p_m, ReadOnlySpan<string> allPostCrossing)
		{
			int[,] mutatedIndexes = new int[n, l];

			//if an index is not mutated, fill it with -1, to differentiate from index 0 (since c# basically assigns 0 to empty field in int array)
			mutatedIndexes = FillMutatedIndexesArrayWithMinus1s(n, l);

			//loop every row, then loop every char (0/1) in each string
			//in order to check condition and find mutated bits
			//WARNING: this function operates on true mutatedIndexes array, without returning
			Fill2DArrayWithMutatedBitsIndexes(n, l, p_m, allPostCrossing, mutatedIndexes);

			return mutatedIndexes;
		}

		public string[] AfterMutationColumnAndFillPostMutationArray(int n, int l, int[,] mutatedIndexes, string[] allPostCrossing)
		{
			//make a copy of post-crossing generation just in case
			string[] postMutation = new string[n];
			Array.Copy(allPostCrossing, postMutation, n);

			for (int i = 0; i < n; ++i)
			{
				for (int j = 0; j < l; ++j)
				{
					int value = mutatedIndexes[i, j];
					if (value != -1)
					{
						if (postMutation[i][j] == '0')
						{
							postMutation[i] = postMutation[i].Remove(j, 1).Insert(j, "1");
						}
						else if (postMutation[i][j] == '1')
						{
							postMutation[i] = postMutation[i].Remove(j, 1).Insert(j, "0");
						}
					}
				}
				dataGridView1[13, i].Value = postMutation[i];
			}

			return postMutation;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			#region Preparations

			this.dataGridView1.Rows.Clear();

			int a, b, l, n;
			float d, p_k, p_m;

			AssignInputValues(out a, out b, out n, out d, out p_k, out p_m);

			int prec = GetPrecInNumber(d);
			l = GetLValue(a, b, d);

			#endregion

			#region Early

			double[] xrealArray = new double[n];
			xrealArray = FillFirstTwoColumnsAndXrealArray(a, b, n, prec);

			double[] fxValuesArray = new double[n];
			fxValuesArray = FillFxColumnAndFxValuesArray(xrealArray);


			//after all fx values are known, proceed to choose fx min and count gx
			double[] gxValuesArray = new double[n];
			gxValuesArray = FillGxColumnAndGxValuesArray(d, fxValuesArray);


			double[] pArray = new double[n];
			pArray = FillP_iColumnAndPArray(gxValuesArray);

			double[] qArray = new double[n];
			qArray = FillQ_iColumnAndQArray(pArray);

			double[] rArray = new double[n];
			rArray = FillRColumnAndRArray(n);


			//xreal selection
			//keep in mind that there may be many xreals that fulfill condition for a given r, it's just finding the first one (by rows) that does it
			double[] selected = new double[n];
			selected = FillSelectedColumnAndSelectedArray(xrealArray, qArray, rArray);


			//write xbins (converted xreals)
			string[] xbinArr = new string[n];
			xbinArr = FillXbinColumnAndXbinArray(a, b, l, selected);

			#endregion

			#region ParentPreparation

			//write parents based on condition with random value, choose until at least 2 parents are chosen (until a first-time xbin is chosen to be parent)
			string[] parents = new string[n];
			parents = FillParentsColumnAndParentsArray(n, p_k, xbinArr);

			//count parents
			int parentCounter = CountParents(n, parents);

			//make an array with proper parents (without nulls or 0's) and an array their indexes
			string[] filteredParents = new string[parentCounter];
			int[] indexesOfFiltered = new int[parentCounter];
			(filteredParents, indexesOfFiltered) = FilterParentsAndTheirIndexes(parentCounter, parents);

			#endregion

			#region Pairing&P_c

			//a list of tuples, with each tuple having 2 parents and a random number they got
			List<Tuple<string, string, int>> pairs = PerformPairingAndAddToListWithRandomNumber(l, filteredParents);

			//get p_c (cutting point) for every pair
			//if parents count is odd, one parent is left with a singular cutting point
			FillP_cColumn(parents, pairs);

			#endregion

			#region Crossing

			//list with children, after crossing
			List<string> children = PerformCrossingAndReturnOnlyChildren(pairs);

			#endregion

			#region PostCrossing

			string[] allPostCrossing = new string[n];
			allPostCrossing = HandlePostCrossingArray(n, children, indexesOfFiltered, xbinArr);

			#endregion

			#region Mutation&Ending

			//array for mutated indexes
			int[,] mutatedIndexes = new int[n, l];

			mutatedIndexes = HandleMutatedBitsArray(n, l, p_m, allPostCrossing);


			//loop every row, then loop every bit in each string
			//in order to mutate strings - certain chars in strings
			//which means certain fields in an array of arrays
			string[] postMutation = new string[n];
			postMutation = AfterMutationColumnAndFillPostMutationArray(n, l, mutatedIndexes, allPostCrossing);

			FillMutatedXrealAndNewFxColumns(a, b, n, l, postMutation, d);

			#endregion
		}
	}
}