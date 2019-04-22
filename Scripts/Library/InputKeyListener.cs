using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Space Walk Author
/// Modfieid By: Adriana Arzola
/// SWEN 5235 - HW 4
/// </summary>
namespace CharControl
{
	public class InputKeyListener
	{
		static InputKeyListener() {}
	    private int _code = -1;

        private static InputKeyListener _listener;
        public static InputKeyListener GetListener()
	    {
	        if (_listener == null)
                _listener = new InputKeyListener();
	        return _listener;
	    }

	    public void RecordInputKey(int code)
	    {
	        _code = code;
	    }

	    public int RetrieveInputKey()
	    {
	        return _code;
	    }
	}
}