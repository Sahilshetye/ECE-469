
/***********************************************************************

        Copyright (C) 1991,
        Virginia Polytechnic Institute & State University

        This program was originally written by Mr. Hyung K. Lee
        under the supervision of Dr. Dong S. Ha, in the Bradley
        Department of Electrical Engineering, VPI&SU, in 1991.

        This program is released for research use only. This program,
        or any derivative thereof, may not be reproduced nor used
        for any commercial product without the written permission
        of the authors.

        For detailed information, please contact to

        Dr. Dong S. Ha
        Bradley Department of Electrical Engineering
        Virginia Polytechnic Institute & State University
        Blacksburg, VA 24061

        Ph.: (540) 231-4942
        Fax: (540) 231-3362
        E-Mail: ha@vt.edu
        Web: http://www.ee.vt.edu/ha

        REFERENCE:
           H. K. Lee and D. S. Ha, "On the Generation of Test Patterns
           for Combinational Circuits," Technical Report No. 12_93,
           Dep't of Electrical Eng., Virginia Polytechnic Institute
           and State University.

***********************************************************************/

/**************************** HISTORY **********************************
 
        atalanta: version 1.1        H. K. Lee, 10/5/1992
        atalanta: version 2.0        H. K. Lee, 6/30/1997
 
***********************************************************************/

/*----------------------------------------------------------------------
	macro.h
	Define macro functions for atalanta.
-----------------------------------------------------------------------*/

#ifndef         __ATALANTA_MACRO_H__
#define         __ATALANTA_MACRO_H__

/* character substitution */
#define         EOS     '\0'    /* End of string */
#define         CR      '\n'    /* carriage return */
#define         TAB     '\t'    /* tab */
 
/* assignment & comparison */
#define set(var) (var=TRUE)
#define reset(var) (var=FALSE)
#define MAX(X,Y) ((X) > (Y) ? (X) : (Y))
#define MIN(X,Y) ((X) > (Y) ? (Y) : (X))
#define max(a,b) ((a) > (b) ? (a) : (b))
#define min(a,b) ((a) > (b) ? (b) : (a))
#define ABS(X) ( X >= 0 ? X : (-1)*X )
#define A_NOT(var)     ((var==ONE) ? ZERO :  \
		       (var==ZERO) ? ONE :  \
		       (var==D) ? DBAR : \
		       (var==DBAR) ? D : X)

/* macros for LIFO stack operation */
#define EMPTY (-1)
#define push(s,ele) s.list[++(s.last)]=ele
#define pop(s) s.list[(s.last)--]
#define clear(s) s.last=EMPTY
#define is_empty(s) (s.last<0)
#define delete_last(s) --(s.last)
#define delete(s,i) s.list[i]=s.list[(s.last)--]
#define copy(s1,s2,i) s2.last=s1.last;\
		      for(i=s1.last;i>=0;i--) s2.list[i]=s1.list[i]

/* macros for event queue operation */
#define pushevent(gate) if(!gate->changed) { \
			push(event_list[gate->dpi],gate); \
			set(gate->changed);}
#define popevent(depth) pop(event_list[depth])
#define clearevent(depth) clear(event_list[depth])
#define schedule_output(gate) \
	for(mac_i=0;mac_i<gate->noutput;mac_i++) \
	   pushevent(gate->outlis[mac_i])
#define schedule_input(gate,i) pushevent(gate->inlis[i]) \
			     schedule_output(gate->inlis[i])

#define pushgate(gut) push(event_list[gut->dpi],gut)
#define schedulegate(gut,ti,temp) \
for(ti=0;ti<gut->noutput;ti++) { \
   temp=gut->outlis[ti]; \
   if(!temp->changed) { \
      set(temp->changed); pushgate(temp); \
}}


#define is_head(line) (line->ltype==HEAD)
#define is_free(line) (line->ltype==LFREE)
#define is_bound(line) (line->ltype==BOUND)
#define is_fanout(line) (line->noutput>1)
#define is_reachable_from_fault(line) (line->freach)
#define is_unspecified(line) (line->output==X)
#define is_justified(line) (line->changed)
#define is_unjustified(line) ((!line->changed)&&(line->output!=X))
#define is_D_propagated(line) (line->output==D || line->output==DBAR)

#define is_undetected(fault) (fault->detected==UNDETECTED)
#define is_detected(fault) (fault->detected==DETECTED)
#define is_redundant(fault) (fault->detected==REDUNDANT)

/* macros for tree operation */
#define current_node tree.list[tree.last]
#define is_flagged(node) node.flag

/* macros for multiple backtrace */
#define setline(line,n0,n1) line->numzero=n0; \
	line->numone=n1
#define resetline(line) setline(line,0,0)
#define is_conflict(line) (line->numzero>0 && line->numone>0)


/********** Macros for memory menagement **********/
extern void *malloc(size_t), *calloc(size_t, size_t), *realloc(void *, size_t);

#define MALLOC(type,number) \
(type *)malloc((unsigned)(sizeof(type)*(number)))
#define CALLOC(type,number) (type *)calloc((unsigned)(sizeof(type)),(unsigned)(number))
#define REALLOC(pointer,type,number) \
pointer = (type *)realloc((char *)pointer,((unsigned)sizeof(type),(unsigned)(number)))
#define MFREE(pointer) \
{ if((pointer)!=NULL) free((char *)pointer); }
#define FREE(pointer) \
{ if((pointer)!=NULL) free((char *)pointer); }
#define ALLOCATE(pointer,type,number) \
if((pointer=MALLOC(type,number))==NULL) fatalerror(MEMORYERROR)
#define CALLOCATE(pointer,type,number) \
if((pointer=CALLOC(type,number))==NULL) fatalerror(MEMORYERROR)


/************ Macros for hope ***************************/
/* macros handling the event list */
#define initeventlist(h,t) \
{ ALLOCATE(t,EVENTTYPE,1); t->next=NULL; h=t; }
#define reseteventlist(h,t,var1) \
{ while(h!=t) { var1=h; h=h->next; FREE(var1); }
#define remove(elist) \
{ tail->next=elist; elist=NULL; while(tail->next!=NULL) tail=tail->next; }
#define create(e) \
{ if(head==tail) {ALLOCATE(e,EVENTTYPE,1); } else { e=head; head=head->next; }}

#define setb(word,p) (word | BITMASK[p])
#define resetb(word,p) (word & (~BITMASK[p]))
#define bitb(word,p) ((word & BITMASK[p]) == ALL0)
#define set0(V0,V1) V0=ALL1; V1=ALL0
#define set1(V0,V1) V0=ALL0; V1=ALL1
#define setx(V0,V1) V0=V1=ALL0
#define setz(V0,V1) V0=V1=ALL1
#define whatis(V0,V1) ((V0==ALL1 && V1==ALL0) ? ZERO : \
		       (V0==ALL0 && V1==ALL1) ? ONE : \
		       (V0==ALL0 && V1==ALL0) ? X : Z)

/* Gate Evaluation */
#define FEVAL(gut,Val,j,v,temp,GGID) \
	switch(gut->fn) { \
	case NOT: \
           if(gut->inlis[0]->Gid==GGID) { \
              Val[0]=gut->inlis[0]->FV[1]; \
              Val[1]=gut->inlis[0]->FV[0]; \
           } else { \
              Val[0]=gut->inlis[0]->GV[1]; \
              Val[1]=gut->inlis[0]->GV[0]; \
           } \
           break; \
	case AND: \
	   if(gut->inlis[0]->Gid==GGID) { \
	      cpylevel(Val,gut->inlis[0]->FV); \
	   } else { cpylevel(Val,gut->inlis[0]->GV); } \
	   for(j=1;j<gut->ninput;j++) \
	      if(gut->inlis[j]->Gid==GGID) { \
	         Val[0] |= gut->inlis[j]->FV[0]; \
	         Val[1] &= gut->inlis[j]->FV[1]; \
	      } else { \
	         Val[0] |= gut->inlis[j]->GV[0]; \
	         Val[1] &= gut->inlis[j]->GV[1]; \
	      } \
	   break; \
	case NAND: \
	   if(gut->inlis[0]->Gid==GGID) { \
	      cpylevel(Val,gut->inlis[0]->FV); \
	   } else { cpylevel(Val,gut->inlis[0]->GV); } \
	   for(j=1;j<gut->ninput;j++) \
	      if(gut->inlis[j]->Gid==GGID) { \
	         Val[0] |= gut->inlis[j]->FV[0]; \
	         Val[1] &= gut->inlis[j]->FV[1]; \
	      } else { \
	         Val[0] |= gut->inlis[j]->GV[0]; \
	         Val[1] &= gut->inlis[j]->GV[1]; \
	      } \
	   v=Val[0]; Val[0]=Val[1]; Val[1]=v; \
	   break; \
	case OR: \
	   if(gut->inlis[0]->Gid==GGID) { \
	      cpylevel(Val,gut->inlis[0]->FV); \
	   } else { cpylevel(Val,gut->inlis[0]->GV); } \
	   for(j=1;j<gut->ninput;j++) \
	      if(gut->inlis[j]->Gid==GGID) { \
	         Val[0] &= gut->inlis[j]->FV[0]; \
	         Val[1] |= gut->inlis[j]->FV[1]; \
	      } else { \
	         Val[0] &= gut->inlis[j]->GV[0]; \
	         Val[1] |= gut->inlis[j]->GV[1]; \
	      } \
	   break; \
	case NOR: \
	   if(gut->inlis[0]->Gid==GGID) { \
	      cpylevel(Val,gut->inlis[0]->FV); \
	   } else { cpylevel(Val,gut->inlis[0]->GV); } \
	   for(j=1;j<gut->ninput;j++) \
	      if(gut->inlis[j]->Gid==GGID) { \
	         Val[0] &= gut->inlis[j]->FV[0]; \
	         Val[1] |= gut->inlis[j]->FV[1]; \
	      } else { \
	         Val[0] &= gut->inlis[j]->GV[0]; \
	         Val[1] |= gut->inlis[j]->GV[1]; \
	      } \
	   v=Val[0]; Val[0]=Val[1]; Val[1]=v; \
	   break; \
	case XOR: \
	   if(gut->inlis[0]->Gid==GGID) { \
	      cpylevel(Val,gut->inlis[0]->FV); \
	   } else { cpylevel(Val,gut->inlis[0]->GV); } \
	   for(j=1;j<gut->ninput;j++) { \
	      temp=gut->inlis[j]; \
	      v=Val[0]; \
	      if(temp->Gid==GGID) { \
	         Val[0] = (v&temp->FV[0])|(Val[1]&temp->FV[1]); \
	         Val[1] = (Val[1]&temp->FV[0])|(v&temp->FV[1]); \
	      } else { \
	         Val[0] = (v&temp->GV[0])|(Val[1]&temp->GV[1]); \
	         Val[1] = (Val[1]&temp->GV[0])|(v&temp->GV[1]); \
	      } \
	   } break; \
	case XNOR: \
	   if(gut->inlis[0]->Gid==GGID) { \
	      cpylevel(Val,gut->inlis[0]->FV); \
	   } else { cpylevel(Val,gut->inlis[0]->GV); } \
	   for(j=1;j<gut->ninput;j++) { \
	      temp=gut->inlis[j]; \
	      v=Val[0]; \
	      if(temp->Gid==GGID) { \
	         Val[0] = (v&temp->FV[0])|(Val[1]&temp->FV[1]); \
	         Val[1] = (Val[1]&temp->FV[0])|(v&temp->FV[1]); \
	      } else { \
	         Val[0] = (v&temp->GV[0])|(Val[1]&temp->GV[1]); \
	         Val[1] = (Val[1]&temp->GV[0])|(v&temp->GV[1]); \
	      } \
	   } \
	   v=Val[0]; Val[0]=Val[1]; Val[1]=v; \
	   break; \
	case DUMMY: case PO: case BUFF: \
	   if(gut->inlis[0]->Gid==GGID) { \
	      cpylevel(Val,gut->inlis[0]->FV); \
	   } else { cpylevel(Val,gut->inlis[0]->GV); } \
	   break; \
        default: \
	   Faulty_Gate_Eval(gut,Val); \
	   break; \
	}

#endif /* __ATALANTA_MACRO_H__ */
