/*
Your goal in this kata is to implement a difference function, which subtracts one list from another and returns the result.

It should remove all values from list a, which are present in list b.

Kata.ArrayDiff(new int[] {1, 2}, new int[] {1}) => new int[] {2}


If a value is present in b, all of its occurrences must be removed from the other:
Kata.ArrayDiff(new int[] {1, 2, 2, 2, 3}, new int[] {2}) => new int[] {1, 3}
*/





using System.Linq;

public class Kata
{
  public static int[] ArrayDiff(int[] a, int[] b)
  {
    for(int i =0; i < b.Length; i++)
    {
     for(int j=0; j<a.Length;j++)
     {
       if(a[j] == b[i])
       {
        a = a.Where(val=> val != b[i]).ToArray();
       }
     }
    }
    return a;
  } 
}


/*
unit test:
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual(new int[] {2},       Kata.ArrayDiff(new int[] {1, 2},    new int[] {1}));
      Assert.AreEqual(new int[] {2, 2},    Kata.ArrayDiff(new int[] {1, 2, 2}, new int[] {1}));
      Assert.AreEqual(new int[] {1},       Kata.ArrayDiff(new int[] {1, 2, 2}, new int[] {2}));
      Assert.AreEqual(new int[] {1, 2, 2}, Kata.ArrayDiff(new int[] {1, 2, 2}, new int[] {}));
      Assert.AreEqual(new int[] {},        Kata.ArrayDiff(new int[] {},        new int[] {1, 2}));
    }
  }
}
*/