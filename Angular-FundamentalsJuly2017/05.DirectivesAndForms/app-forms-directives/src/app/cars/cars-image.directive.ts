import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
    selector: '[roundedBorder]'
})
export class CarImageDirective {
    border: string;

    // angular uses host listener to detach automatically events when they are not used
    // we can attach events with oninit func but must detach them with ondestroy
    @HostListener('mouseenter') onmouseenter() {
        this.changeBorder(this.border);
    }

    @HostListener('mouseleave') onmouseleave() {
        this.changeBorder(null);
    }

    constructor(private el: ElementRef) { 
        this.border = "10px solid red";
    }

    private changeBorder(border) {
        this.el.nativeElement.style.border = border;
    }
}