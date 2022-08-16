/**
 * Class to represent a MinHeap which is a Priority Queue optimized for fast
 * retrieval of the minimum value. It is implemented using an array but it is
 * best visualized as a tree structure where each 'node' has left and right
 * children except the 'node' may only have a left child.
 * - parent is located at: Math.floor(i / 2);
 * - left child is located at: i * 2
 * - right child is located at: i * 2 + 1
 */
class MinHeap {
    constructor() {
        /**
         * 0th index not used, so null is a placeholder. Not using 0th index makes
         * calculating the left and right children's index cleaner.
         * This also effectively makes our array start at index 1.
         */
        this.heap = [null];
    }

    /**
       * @param {number} i
       */
    idxOfParent(i) {
        return Math.floor(i / 2);
    }

    /**
       * @param {number} i
       */
    idxOfLeftChild(i) {
          return i * 2;
    }

    /**
     * @param {number} i
     */
    idxOfRightChild(i) {
        return i * 2 + 1;
    }

    /**
     * Swaps two nodes.
     * @param {number} i
     * @param {number} j
     */
    swap(i, j) {
        [this.heap[i], this.heap[j]] = [this.heap[j], this.heap[i]];
    }

    /**
     * Extracts the min num from the heap and then re-orders the heap to
     * maintain order so the next min is ready to be extracted.
     * 1. Save the first node to a temp var.
     * 2. Pop last node off and set idx1 equal to the popped value.
     * 3. Iteratively swap the old last node that is now at idx1 with it's
     *    smallest child IF the smallest child is smaller than it.
     * - Time: O(log n) logarithmic due to shiftDown.
     * - Space: O(1) constant.
     * @returns {?number} The min number or null if empty.
     */
    extract() {
        let temp = this.top()
        if (temp == null){
            return null
        }

        this.heap[1] == this.heap.pop();
        
        this.heap[1].shiftDown()
        return this.size();


    }

    top() {
        return this.heap.length > 1 ? this.heap[1] : null;
    }

    /**
     * Inserts a new number into the heap and reorders heap to maintain order.
     * 1. Push new num to back.
     * 2. Iteratively swap the new num with it's parent while it is smaller than
     *    it's parent.
     * - Time: O(log n) logarithmic due to shiftUp.
     * - Space: O(1) constant.
     * @param {number} num The num to add.
     */
    insert(num) {
        // if num input is a number run code

    this.heap.push(num);
    // pointers
    let last = this.heap.length - 1;
    let parent = Math.floor(last / 2);

    // keep checking if the inserted number is less than its parent, if it is swap them
    while (this.heap[last] < this.heap[parent]) {
        [this.heap[last], this.heap[parent]] = [
        this.heap[parent],
        this.heap[last],
        ];
        last = parent;
        parent = Math.floor(parent / 2);
    }

    return this;

    }

    // AKA: siftUp, heapifyUp, bubbleUp to restore order after insert
    shiftUp() {
        let idxOfNodeToShiftUp = this.heap.length - 1;

        while (idxOfNodeToShiftUp > 1) {
            const idxOfParent = this.idxOfParent(idxOfNodeToShiftUp);

            const isParentSmallerOrEqual =
            this.heap[idxOfParent] <= this.heap[idxOfNodeToShiftUp];

            // Parent is supposed to be smaller so ordering is complete.
            if (isParentSmallerOrEqual) {
            break;
            }

            this.swap(idxOfNodeToShiftUp, idxOfParent);
            // after swapping the node is at idxOfParent now.
            idxOfNodeToShiftUp = idxOfParent;
        }
    }

    /**
     * Logs the tree horizontally with the root on the left and the index in
     * parenthesis using reverse inorder traversal.
     */
    printHorizontalTree(parentIdx = 1, spaceCnt = 0, spaceIncr = 10) {
        if (parentIdx > this.heap.length - 1) {
        return;
        }

        spaceCnt += spaceIncr;
        this.printHorizontalTree(parentIdx * 2 + 1, spaceCnt);

        console.log(
        " ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +
            `${this.heap[parentIdx]} (${parentIdx})`
        );

        this.printHorizontalTree(parentIdx * 2, spaceCnt);
    }
}
const fullHeap = new MinHeap();
fullHeap.insert(1);
fullHeap.insert(2);
fullHeap.insert(5);
fullHeap.insert(6);
fullHeap.insert(3);

fullHeap.printHorizontalTree();
fullHeap.shiftUp(1);
