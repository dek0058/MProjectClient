using UnityEngine;
using System;
using MProject.Utility.PriorityQueue;

namespace MProject.Animation {
    
    public class LayerNode : FastPriorityQueueNode {
        public Int32 id;
    }

    [Serializable]
    public class AnimationController {
        private const int MAX_SIZE = 255;
        private static string PARAMETER_ID = "ID";
        private static string PARAMETER_RUN = "RUN";

        public Animator animator;
        public FastPriorityQueue<LayerNode> anim_queue = new FastPriorityQueue<LayerNode>(MAX_SIZE/*max size*/);
        
        private bool is_ready = false;
        public bool Ready { set => is_ready = value; }


        public void Add(AnimationPrority _prority, Int32 _id) {
            if(anim_queue.Count == MAX_SIZE) {
                return;
            }
            Ready = true;
            anim_queue.Enqueue(new LayerNode { id = _id }, (float)_prority);
        }

        public void Set(AnimationPrority _prority, Int32 _id) {
            anim_queue.Clear();
            Ready = true;
            anim_queue.Enqueue(new LayerNode { id = _id }, (float)_prority);
        }

        public void Update() {
            if(false == is_ready) {
                return;
            }
            if (anim_queue.Count == 0) {
                return;
            }
            var node = anim_queue.Dequeue();
            animator.SetInteger(PARAMETER_ID, node.id);
            animator.SetTrigger(PARAMETER_RUN);
        }
    }
}
