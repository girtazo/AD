package juankza;

import static org.junit.Assert.*;
import junit.framework.Assert;

import org.junit.Test;

public class VectorTest
{
	@Test
	public void testMin()
	{
		assertEquals(0, Vector.min(new int[] {30, 50, 10, 0, 40, 20}));
		assertEquals(0, Vector.min(new int[] {0, 50, 10, 30, 40, 20}));
		assertEquals(0, Vector.min(new int[] {30, 50, 10, 20, 40, 0}));
		
	}

	@Test(expected = ArrayIndexOutOfBoundsException.class)
	public void testMinEmpty()
	{ Vector.min(new int[] { });}
	
}
