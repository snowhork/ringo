using System.Collections;
using System.Collections.Generic;
using Script.Postions;
using UnityEngine;

public class SyncInput : MonoBehaviour
{

	private Point _point;

	public Point Point
	{
		get { return _point; }
		set
		{
			_point = value;
			_x = _point.X;
		}
	}

	void OnPhotonSerializeView( PhotonStream i_stream, PhotonMessageInfo i_info )
	{
		if( i_stream.isWriting )
		{
			//データの送信
			i_stream.SendNext( _point.X );
			i_stream.SendNext( _point.Y );
		}
		else
		{
			//データの受信
			var x = (int)i_stream.ReceiveNext();
			var y = (int)i_stream.ReceiveNext();
			Point = new Point(x, y);
		}
	}

	[SerializeField] private int _x;

}
