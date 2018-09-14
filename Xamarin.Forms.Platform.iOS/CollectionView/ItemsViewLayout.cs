﻿using System;
using System.Runtime.CompilerServices;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Xamarin.Forms.Platform.iOS
{
	public abstract class ItemsViewLayout : UICollectionViewFlowLayout, IUICollectionViewDelegateFlowLayout
	{
		public nfloat ConstrainedDimension { get; set; }

		public abstract void ConstrainTo(CGSize size);

		public abstract void PrepareCellForLayout(IConstrainedCell cell);

		[Export("collectionView:layout:insetForSectionAtIndex:"), CompilerGenerated]
		public virtual UIEdgeInsets GetInsetForSection(UICollectionView collectionView, UICollectionViewLayout layout, int section)
		{
			return UIEdgeInsets.Zero;
		}

		[Export("collectionView:layout:minimumInteritemSpacingForSectionAtIndex:"), CompilerGenerated]
		public virtual nfloat GetMinimumInteritemSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, int section)
		{
			return (nfloat)0.0;
		}

		[Export("collectionView:layout:minimumLineSpacingForSectionAtIndex:"), CompilerGenerated]
		public virtual nfloat GetMinimumLineSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, int section)
		{
			return (nfloat)0.0;
		}

		public event EventHandler<EventArgs> NeedsEstimate;

		public bool RequestingEstimate { get; private set; } = true;

		protected virtual void OnNeedsEstimate()
		{
			RequestingEstimate = true;
			NeedsEstimate?.Invoke(this, EventArgs.Empty);
		}

		public void SetEstimate(CGSize cellSize, bool uniformSize)
		{
			if (uniformSize)
			{
				ItemSize = cellSize;
			}
			else
			{
				EstimatedItemSize = cellSize;
			}

			RequestingEstimate = false;
		}
	}
}