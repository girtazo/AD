package juankza;

public class Vector
{
	public static int min(int[] v)
	{
		int min = v[0];
		
		for(int index = 0; index < v.length; index++)
			if(v[index] < min)
				min = v[index];
			
		return min;
		
	}

	public static void main(String[] args)
	{
		//int[] v = {30, 50, 10, 0, 40, 20};
		
		//System.out.println(min(v));

	}
	
}
