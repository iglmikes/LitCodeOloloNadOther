using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitCodeOloloNadOther.SupportModels
{
  
    // Definition for singly-linked list.
     public class ListNode {
         public int val;
         public ListNode next;
     public ListNode(int val=0, ListNode next=null) {
             this.val = val;
             this.next = next;
         }
        public ListNode(int[] Arr, int offset = 0)
        {
            if (Arr == null)
            {
                
            }
            else if(offset < Arr.Length) 
            {
                val = Arr[offset];
                if(offset < Arr.Length-1)
                    next = new ListNode(Arr, offset+1);
                
            }
            else
            {
               
            }
        }

       

      }
    
}
