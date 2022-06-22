import { animate, style, transition, trigger } from "@angular/animations";

export const OPACITY_ANIMATION =  trigger(
    'opacityAnimation', [
      transition(':enter', [
        style({opacity:0}),
        animate(300, style({opacity:1})) 
        ]),
      transition(':leave', [
        transition(':leave', [ 
        animate(2000, style({opacity:0})) 
        ])  
      ])
    ],
  )