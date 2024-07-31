public static class ArrayExtension
{
  private static void Reverse(int[] a)
    => Reverse(a, a.Length);

  private static void Reverse(int[] a, int n)
  {
    for (var i = 0; i < n / 2; i++)
      (a[i], a[n - i - 1]) = (a[n - i - 1], a[i]);
  }
}
