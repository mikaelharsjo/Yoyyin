jQuery.fn.center = function (absolute) { return this.each(function () { var t = jQuery(this); t.css({ position: absolute ? 'absolute' : 'fixed', left: '50%', top: '50%', zIndex: '99' }).css({ marginLeft: '-' + (t.outerWidth() / 2) + 'px', marginTop: '-' + (t.outerHeight() / 2) + 'px' }); if (absolute) { t.css({ marginTop: parseInt(t.css('marginTop'), 10) + jQuery(window).scrollTop(), marginLeft: parseInt(t.css('marginLeft'), 10) + jQuery(window).scrollLeft() }) } }) };

/**
* hoverIntent r5 // 2007.03.27 // jQuery 1.1.2+
* <http://cherne.net/brian/resources/jquery.hoverIntent.html>
* 
* @param  f  onMouseOver function || An object with configuration options
* @param  g  onMouseOut function  || Nothing (use configuration options object)
* @author    Brian Cherne <brian@cherne.net>
*/
(function ($) { $.fn.hoverIntent = function (f, g) { var cfg = { sensitivity: 7, interval: 100, timeout: 0 }; cfg = $.extend(cfg, g ? { over: f, out: g} : f); var cX, cY, pX, pY; var track = function (ev) { cX = ev.pageX; cY = ev.pageY; }; var compare = function (ev, ob) { ob.hoverIntent_t = clearTimeout(ob.hoverIntent_t); if ((Math.abs(pX - cX) + Math.abs(pY - cY)) < cfg.sensitivity) { $(ob).unbind("mousemove", track); ob.hoverIntent_s = 1; return cfg.over.apply(ob, [ev]); } else { pX = cX; pY = cY; ob.hoverIntent_t = setTimeout(function () { compare(ev, ob); }, cfg.interval); } }; var delay = function (ev, ob) { ob.hoverIntent_t = clearTimeout(ob.hoverIntent_t); ob.hoverIntent_s = 0; return cfg.out.apply(ob, [ev]); }; var handleHover = function (e) { var p = (e.type == "mouseover" ? e.fromElement : e.toElement) || e.relatedTarget; while (p && p != this) { try { p = p.parentNode; } catch (e) { p = this; } } if (p == this) { return false; } var ev = jQuery.extend({}, e); var ob = this; if (ob.hoverIntent_t) { ob.hoverIntent_t = clearTimeout(ob.hoverIntent_t); } if (e.type == "mouseover") { pX = ev.pageX; pY = ev.pageY; $(ob).bind("mousemove", track); if (ob.hoverIntent_s != 1) { ob.hoverIntent_t = setTimeout(function () { compare(ev, ob); }, cfg.interval); } } else { $(ob).unbind("mousemove", track); if (ob.hoverIntent_s == 1) { ob.hoverIntent_t = setTimeout(function () { delay(ev, ob); }, cfg.timeout); } } }; return this.mouseover(handleHover).mouseout(handleHover); }; })(jQuery);

/*
* jQuery UI Effects 1.8.10
*
* Copyright 2011, AUTHORS.txt (http://jqueryui.com/about)
* Dual licensed under the MIT or GPL Version 2 licenses.
* http://jquery.org/license
*
* http://docs.jquery.com/UI/Effects/
*/
jQuery.effects || function (f, j) {
    function n(c) {
        var a; if (c && c.constructor == Array && c.length == 3) return c; if (a = /rgb\(\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*\)/.exec(c)) return [parseInt(a[1], 10), parseInt(a[2], 10), parseInt(a[3], 10)]; if (a = /rgb\(\s*([0-9]+(?:\.[0-9]+)?)\%\s*,\s*([0-9]+(?:\.[0-9]+)?)\%\s*,\s*([0-9]+(?:\.[0-9]+)?)\%\s*\)/.exec(c)) return [parseFloat(a[1]) * 2.55, parseFloat(a[2]) * 2.55, parseFloat(a[3]) * 2.55]; if (a = /#([a-fA-F0-9]{2})([a-fA-F0-9]{2})([a-fA-F0-9]{2})/.exec(c)) return [parseInt(a[1],
16), parseInt(a[2], 16), parseInt(a[3], 16)]; if (a = /#([a-fA-F0-9])([a-fA-F0-9])([a-fA-F0-9])/.exec(c)) return [parseInt(a[1] + a[1], 16), parseInt(a[2] + a[2], 16), parseInt(a[3] + a[3], 16)]; if (/rgba\(0, 0, 0, 0\)/.exec(c)) return o.transparent; return o[f.trim(c).toLowerCase()]
    } function s(c, a) { var b; do { b = f.curCSS(c, a); if (b != "" && b != "transparent" || f.nodeName(c, "body")) break; a = "backgroundColor" } while (c = c.parentNode); return n(b) } function p() {
        var c = document.defaultView ? document.defaultView.getComputedStyle(this, null) : this.currentStyle,
a = {}, b, d; if (c && c.length && c[0] && c[c[0]]) for (var e = c.length; e--; ) { b = c[e]; if (typeof c[b] == "string") { d = b.replace(/\-(\w)/g, function (g, h) { return h.toUpperCase() }); a[d] = c[b] } } else for (b in c) if (typeof c[b] === "string") a[b] = c[b]; return a
    } function q(c) { var a, b; for (a in c) { b = c[a]; if (b == null || f.isFunction(b) || a in t || /scrollbar/.test(a) || !/color/i.test(a) && isNaN(parseFloat(b))) delete c[a] } return c } function u(c, a) { var b = { _: 0 }, d; for (d in a) if (c[d] != a[d]) b[d] = a[d]; return b } function k(c, a, b, d) {
        if (typeof c == "object") {
            d =
a; b = null; a = c; c = a.effect
        } if (f.isFunction(a)) { d = a; b = null; a = {} } if (typeof a == "number" || f.fx.speeds[a]) { d = b; b = a; a = {} } if (f.isFunction(b)) { d = b; b = null } a = a || {}; b = b || a.duration; b = f.fx.off ? 0 : typeof b == "number" ? b : b in f.fx.speeds ? f.fx.speeds[b] : f.fx.speeds._default; d = d || a.complete; return [c, a, b, d]
    } function m(c) { if (!c || typeof c === "number" || f.fx.speeds[c]) return true; if (typeof c === "string" && !f.effects[c]) return true; return false } f.effects = {}; f.each(["backgroundColor", "borderBottomColor", "borderLeftColor", "borderRightColor",
"borderTopColor", "borderColor", "color", "outlineColor"], function (c, a) { f.fx.step[a] = function (b) { if (!b.colorInit) { b.start = s(b.elem, a); b.end = n(b.end); b.colorInit = true } b.elem.style[a] = "rgb(" + Math.max(Math.min(parseInt(b.pos * (b.end[0] - b.start[0]) + b.start[0], 10), 255), 0) + "," + Math.max(Math.min(parseInt(b.pos * (b.end[1] - b.start[1]) + b.start[1], 10), 255), 0) + "," + Math.max(Math.min(parseInt(b.pos * (b.end[2] - b.start[2]) + b.start[2], 10), 255), 0) + ")" } }); var o = { aqua: [0, 255, 255], azure: [240, 255, 255], beige: [245, 245, 220], black: [0,
0, 0], blue: [0, 0, 255], brown: [165, 42, 42], cyan: [0, 255, 255], darkblue: [0, 0, 139], darkcyan: [0, 139, 139], darkgrey: [169, 169, 169], darkgreen: [0, 100, 0], darkkhaki: [189, 183, 107], darkmagenta: [139, 0, 139], darkolivegreen: [85, 107, 47], darkorange: [255, 140, 0], darkorchid: [153, 50, 204], darkred: [139, 0, 0], darksalmon: [233, 150, 122], darkviolet: [148, 0, 211], fuchsia: [255, 0, 255], gold: [255, 215, 0], green: [0, 128, 0], indigo: [75, 0, 130], khaki: [240, 230, 140], lightblue: [173, 216, 230], lightcyan: [224, 255, 255], lightgreen: [144, 238, 144], lightgrey: [211,
211, 211], lightpink: [255, 182, 193], lightyellow: [255, 255, 224], lime: [0, 255, 0], magenta: [255, 0, 255], maroon: [128, 0, 0], navy: [0, 0, 128], olive: [128, 128, 0], orange: [255, 165, 0], pink: [255, 192, 203], purple: [128, 0, 128], violet: [128, 0, 128], red: [255, 0, 0], silver: [192, 192, 192], white: [255, 255, 255], yellow: [255, 255, 0], transparent: [255, 255, 255]
}, r = ["add", "remove", "toggle"], t = { border: 1, borderBottom: 1, borderColor: 1, borderLeft: 1, borderRight: 1, borderTop: 1, borderWidth: 1, margin: 1, padding: 1 }; f.effects.animateClass = function (c, a, b,
d) {
    if (f.isFunction(b)) { d = b; b = null } return this.queue("fx", function () {
        var e = f(this), g = e.attr("style") || " ", h = q(p.call(this)), l, v = e.attr("className"); f.each(r, function (w, i) { c[i] && e[i + "Class"](c[i]) }); l = q(p.call(this)); e.attr("className", v); e.animate(u(h, l), a, b, function () { f.each(r, function (w, i) { c[i] && e[i + "Class"](c[i]) }); if (typeof e.attr("style") == "object") { e.attr("style").cssText = ""; e.attr("style").cssText = g } else e.attr("style", g); d && d.apply(this, arguments) }); h = f.queue(this); l = h.splice(h.length - 1, 1)[0];
        h.splice(1, 0, l); f.dequeue(this)
    })
}; f.fn.extend({ _addClass: f.fn.addClass, addClass: function (c, a, b, d) { return a ? f.effects.animateClass.apply(this, [{ add: c }, a, b, d]) : this._addClass(c) }, _removeClass: f.fn.removeClass, removeClass: function (c, a, b, d) { return a ? f.effects.animateClass.apply(this, [{ remove: c }, a, b, d]) : this._removeClass(c) }, _toggleClass: f.fn.toggleClass, toggleClass: function (c, a, b, d, e) {
    return typeof a == "boolean" || a === j ? b ? f.effects.animateClass.apply(this, [a ? { add: c} : { remove: c }, b, d, e]) : this._toggleClass(c,
a) : f.effects.animateClass.apply(this, [{ toggle: c }, a, b, d])
}, switchClass: function (c, a, b, d, e) { return f.effects.animateClass.apply(this, [{ add: a, remove: c }, b, d, e]) } 
}); f.extend(f.effects, { version: "1.8.10", save: function (c, a) { for (var b = 0; b < a.length; b++) a[b] !== null && c.data("ec.storage." + a[b], c[0].style[a[b]]) }, restore: function (c, a) { for (var b = 0; b < a.length; b++) a[b] !== null && c.css(a[b], c.data("ec.storage." + a[b])) }, setMode: function (c, a) { if (a == "toggle") a = c.is(":hidden") ? "show" : "hide"; return a }, getBaseline: function (c,
a) { var b; switch (c[0]) { case "top": b = 0; break; case "middle": b = 0.5; break; case "bottom": b = 1; break; default: b = c[0] / a.height } switch (c[1]) { case "left": c = 0; break; case "center": c = 0.5; break; case "right": c = 1; break; default: c = c[1] / a.width } return { x: c, y: b} }, createWrapper: function (c) {
    if (c.parent().is(".ui-effects-wrapper")) return c.parent(); var a = { width: c.outerWidth(true), height: c.outerHeight(true), "float": c.css("float") }, b = f("<div></div>").addClass("ui-effects-wrapper").css({ fontSize: "100%", background: "transparent",
        border: "none", margin: 0, padding: 0
    }); c.wrap(b); b = c.parent(); if (c.css("position") == "static") { b.css({ position: "relative" }); c.css({ position: "relative" }) } else { f.extend(a, { position: c.css("position"), zIndex: c.css("z-index") }); f.each(["top", "left", "bottom", "right"], function (d, e) { a[e] = c.css(e); if (isNaN(parseInt(a[e], 10))) a[e] = "auto" }); c.css({ position: "relative", top: 0, left: 0, right: "auto", bottom: "auto" }) } return b.css(a).show()
}, removeWrapper: function (c) {
    if (c.parent().is(".ui-effects-wrapper")) return c.parent().replaceWith(c);
    return c
}, setTransition: function (c, a, b, d) { d = d || {}; f.each(a, function (e, g) { unit = c.cssUnit(g); if (unit[0] > 0) d[g] = unit[0] * b + unit[1] }); return d } 
}); f.fn.extend({ effect: function (c) { var a = k.apply(this, arguments), b = { options: a[1], duration: a[2], callback: a[3] }; a = b.options.mode; var d = f.effects[c]; if (f.fx.off || !d) return a ? this[a](b.duration, b.callback) : this.each(function () { b.callback && b.callback.call(this) }); return d.call(this, b) }, _show: f.fn.show, show: function (c) {
    if (m(c)) return this._show.apply(this, arguments);
    else { var a = k.apply(this, arguments); a[1].mode = "show"; return this.effect.apply(this, a) } 
}, _hide: f.fn.hide, hide: function (c) { if (m(c)) return this._hide.apply(this, arguments); else { var a = k.apply(this, arguments); a[1].mode = "hide"; return this.effect.apply(this, a) } }, __toggle: f.fn.toggle, toggle: function (c) { if (m(c) || typeof c === "boolean" || f.isFunction(c)) return this.__toggle.apply(this, arguments); else { var a = k.apply(this, arguments); a[1].mode = "toggle"; return this.effect.apply(this, a) } }, cssUnit: function (c) {
    var a = this.css(c),
b = []; f.each(["em", "px", "%", "pt"], function (d, e) { if (a.indexOf(e) > 0) b = [parseFloat(a), e] }); return b
} 
}); f.easing.jswing = f.easing.swing; f.extend(f.easing, { def: "easeOutQuad", swing: function (c, a, b, d, e) { return f.easing[f.easing.def](c, a, b, d, e) }, easeInQuad: function (c, a, b, d, e) { return d * (a /= e) * a + b }, easeOutQuad: function (c, a, b, d, e) { return -d * (a /= e) * (a - 2) + b }, easeInOutQuad: function (c, a, b, d, e) { if ((a /= e / 2) < 1) return d / 2 * a * a + b; return -d / 2 * (--a * (a - 2) - 1) + b }, easeInCubic: function (c, a, b, d, e) { return d * (a /= e) * a * a + b }, easeOutCubic: function (c,
a, b, d, e) { return d * ((a = a / e - 1) * a * a + 1) + b }, easeInOutCubic: function (c, a, b, d, e) { if ((a /= e / 2) < 1) return d / 2 * a * a * a + b; return d / 2 * ((a -= 2) * a * a + 2) + b }, easeInQuart: function (c, a, b, d, e) { return d * (a /= e) * a * a * a + b }, easeOutQuart: function (c, a, b, d, e) { return -d * ((a = a / e - 1) * a * a * a - 1) + b }, easeInOutQuart: function (c, a, b, d, e) { if ((a /= e / 2) < 1) return d / 2 * a * a * a * a + b; return -d / 2 * ((a -= 2) * a * a * a - 2) + b }, easeInQuint: function (c, a, b, d, e) { return d * (a /= e) * a * a * a * a + b }, easeOutQuint: function (c, a, b, d, e) { return d * ((a = a / e - 1) * a * a * a * a + 1) + b }, easeInOutQuint: function (c,
a, b, d, e) { if ((a /= e / 2) < 1) return d / 2 * a * a * a * a * a + b; return d / 2 * ((a -= 2) * a * a * a * a + 2) + b }, easeInSine: function (c, a, b, d, e) { return -d * Math.cos(a / e * (Math.PI / 2)) + d + b }, easeOutSine: function (c, a, b, d, e) { return d * Math.sin(a / e * (Math.PI / 2)) + b }, easeInOutSine: function (c, a, b, d, e) { return -d / 2 * (Math.cos(Math.PI * a / e) - 1) + b }, easeInExpo: function (c, a, b, d, e) { return a == 0 ? b : d * Math.pow(2, 10 * (a / e - 1)) + b }, easeOutExpo: function (c, a, b, d, e) { return a == e ? b + d : d * (-Math.pow(2, -10 * a / e) + 1) + b }, easeInOutExpo: function (c, a, b, d, e) {
    if (a == 0) return b; if (a ==
e) return b + d; if ((a /= e / 2) < 1) return d / 2 * Math.pow(2, 10 * (a - 1)) + b; return d / 2 * (-Math.pow(2, -10 * --a) + 2) + b
}, easeInCirc: function (c, a, b, d, e) { return -d * (Math.sqrt(1 - (a /= e) * a) - 1) + b }, easeOutCirc: function (c, a, b, d, e) { return d * Math.sqrt(1 - (a = a / e - 1) * a) + b }, easeInOutCirc: function (c, a, b, d, e) { if ((a /= e / 2) < 1) return -d / 2 * (Math.sqrt(1 - a * a) - 1) + b; return d / 2 * (Math.sqrt(1 - (a -= 2) * a) + 1) + b }, easeInElastic: function (c, a, b, d, e) {
    c = 1.70158; var g = 0, h = d; if (a == 0) return b; if ((a /= e) == 1) return b + d; g || (g = e * 0.3); if (h < Math.abs(d)) { h = d; c = g / 4 } else c =
g / (2 * Math.PI) * Math.asin(d / h); return -(h * Math.pow(2, 10 * (a -= 1)) * Math.sin((a * e - c) * 2 * Math.PI / g)) + b
}, easeOutElastic: function (c, a, b, d, e) { c = 1.70158; var g = 0, h = d; if (a == 0) return b; if ((a /= e) == 1) return b + d; g || (g = e * 0.3); if (h < Math.abs(d)) { h = d; c = g / 4 } else c = g / (2 * Math.PI) * Math.asin(d / h); return h * Math.pow(2, -10 * a) * Math.sin((a * e - c) * 2 * Math.PI / g) + d + b }, easeInOutElastic: function (c, a, b, d, e) {
    c = 1.70158; var g = 0, h = d; if (a == 0) return b; if ((a /= e / 2) == 2) return b + d; g || (g = e * 0.3 * 1.5); if (h < Math.abs(d)) { h = d; c = g / 4 } else c = g / (2 * Math.PI) * Math.asin(d /
h); if (a < 1) return -0.5 * h * Math.pow(2, 10 * (a -= 1)) * Math.sin((a * e - c) * 2 * Math.PI / g) + b; return h * Math.pow(2, -10 * (a -= 1)) * Math.sin((a * e - c) * 2 * Math.PI / g) * 0.5 + d + b
}, easeInBack: function (c, a, b, d, e, g) { if (g == j) g = 1.70158; return d * (a /= e) * a * ((g + 1) * a - g) + b }, easeOutBack: function (c, a, b, d, e, g) { if (g == j) g = 1.70158; return d * ((a = a / e - 1) * a * ((g + 1) * a + g) + 1) + b }, easeInOutBack: function (c, a, b, d, e, g) { if (g == j) g = 1.70158; if ((a /= e / 2) < 1) return d / 2 * a * a * (((g *= 1.525) + 1) * a - g) + b; return d / 2 * ((a -= 2) * a * (((g *= 1.525) + 1) * a + g) + 2) + b }, easeInBounce: function (c,
a, b, d, e) { return d - f.easing.easeOutBounce(c, e - a, 0, d, e) + b }, easeOutBounce: function (c, a, b, d, e) { return (a /= e) < 1 / 2.75 ? d * 7.5625 * a * a + b : a < 2 / 2.75 ? d * (7.5625 * (a -= 1.5 / 2.75) * a + 0.75) + b : a < 2.5 / 2.75 ? d * (7.5625 * (a -= 2.25 / 2.75) * a + 0.9375) + b : d * (7.5625 * (a -= 2.625 / 2.75) * a + 0.984375) + b }, easeInOutBounce: function (c, a, b, d, e) { if (a < e / 2) return f.easing.easeInBounce(c, a * 2, 0, d, e) * 0.5 + b; return f.easing.easeOutBounce(c, a * 2 - e, 0, d, e) * 0.5 + d * 0.5 + b } 
})
} (jQuery);
;

/*
 * File:        jquery.dataTables.min.js
 * Version:     1.7.6
 * Author:      Allan Jardine (www.sprymedia.co.uk)
 * Info:        www.datatables.net
 * 
 * Copyright 2008-2011 Allan Jardine, all rights reserved.
 *
 * This source file is free software, under either the GPL v2 license or a
 * BSD style license, as supplied with this software.
 * 
 * This source file is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
 * or FITNESS FOR A PARTICULAR PURPOSE. See the license files for details.
 */
(function(j,ra,p){j.fn.dataTableSettings=[];var D=j.fn.dataTableSettings;j.fn.dataTableExt={};var n=j.fn.dataTableExt;n.sVersion="1.7.6";n.sErrMode="alert";n.iApiIndex=0;n.oApi={};n.afnFiltering=[];n.aoFeatures=[];n.ofnSearch={};n.afnSortData=[];n.oStdClasses={sPagePrevEnabled:"paginate_enabled_previous",sPagePrevDisabled:"paginate_disabled_previous",sPageNextEnabled:"paginate_enabled_next",sPageNextDisabled:"paginate_disabled_next",sPageJUINext:"",sPageJUIPrev:"",sPageButton:"paginate_button",sPageButtonActive:"paginate_active",
sPageButtonStaticDisabled:"paginate_button",sPageFirst:"first",sPagePrevious:"previous",sPageNext:"next",sPageLast:"last",sStripOdd:"odd",sStripEven:"even",sRowEmpty:"dataTables_empty",sWrapper:"dataTables_wrapper",sFilter:"dataTables_filter",sInfo:"dataTables_info",sPaging:"dataTables_paginate paging_",sLength:"dataTables_length",sProcessing:"dataTables_processing",sSortAsc:"sorting_asc",sSortDesc:"sorting_desc",sSortable:"sorting",sSortableAsc:"sorting_asc_disabled",sSortableDesc:"sorting_desc_disabled",
sSortableNone:"sorting_disabled",sSortColumn:"sorting_",sSortJUIAsc:"",sSortJUIDesc:"",sSortJUI:"",sSortJUIAscAllowed:"",sSortJUIDescAllowed:"",sSortJUIWrapper:"",sScrollWrapper:"dataTables_scroll",sScrollHead:"dataTables_scrollHead",sScrollHeadInner:"dataTables_scrollHeadInner",sScrollBody:"dataTables_scrollBody",sScrollFoot:"dataTables_scrollFoot",sScrollFootInner:"dataTables_scrollFootInner",sFooterTH:""};n.oJUIClasses={sPagePrevEnabled:"fg-button ui-button ui-state-default ui-corner-left",sPagePrevDisabled:"fg-button ui-button ui-state-default ui-corner-left ui-state-disabled",
sPageNextEnabled:"fg-button ui-button ui-state-default ui-corner-right",sPageNextDisabled:"fg-button ui-button ui-state-default ui-corner-right ui-state-disabled",sPageJUINext:"ui-icon ui-icon-circle-arrow-e",sPageJUIPrev:"ui-icon ui-icon-circle-arrow-w",sPageButton:"fg-button ui-button ui-state-default",sPageButtonActive:"fg-button ui-button ui-state-default ui-state-disabled",sPageButtonStaticDisabled:"fg-button ui-button ui-state-default ui-state-disabled",sPageFirst:"first ui-corner-tl ui-corner-bl",
sPagePrevious:"previous",sPageNext:"next",sPageLast:"last ui-corner-tr ui-corner-br",sStripOdd:"odd",sStripEven:"even",sRowEmpty:"dataTables_empty",sWrapper:"dataTables_wrapper",sFilter:"dataTables_filter",sInfo:"dataTables_info",sPaging:"dataTables_paginate fg-buttonset ui-buttonset fg-buttonset-multi ui-buttonset-multi paging_",sLength:"dataTables_length",sProcessing:"dataTables_processing",sSortAsc:"ui-state-default",sSortDesc:"ui-state-default",sSortable:"ui-state-default",sSortableAsc:"ui-state-default",
sSortableDesc:"ui-state-default",sSortableNone:"ui-state-default",sSortColumn:"sorting_",sSortJUIAsc:"css_right ui-icon ui-icon-triangle-1-n",sSortJUIDesc:"css_right ui-icon ui-icon-triangle-1-s",sSortJUI:"css_right ui-icon ui-icon-carat-2-n-s",sSortJUIAscAllowed:"css_right ui-icon ui-icon-carat-1-n",sSortJUIDescAllowed:"css_right ui-icon ui-icon-carat-1-s",sSortJUIWrapper:"DataTables_sort_wrapper",sScrollWrapper:"dataTables_scroll",sScrollHead:"dataTables_scrollHead ui-state-default",sScrollHeadInner:"dataTables_scrollHeadInner",
sScrollBody:"dataTables_scrollBody",sScrollFoot:"dataTables_scrollFoot ui-state-default",sScrollFootInner:"dataTables_scrollFootInner",sFooterTH:"ui-state-default"};n.oPagination={two_button:{fnInit:function(g,m,r){var s,w,y;if(g.bJUI){s=p.createElement("a");w=p.createElement("a");y=p.createElement("span");y.className=g.oClasses.sPageJUINext;w.appendChild(y);y=p.createElement("span");y.className=g.oClasses.sPageJUIPrev;s.appendChild(y)}else{s=p.createElement("div");w=p.createElement("div")}s.className=
g.oClasses.sPagePrevDisabled;w.className=g.oClasses.sPageNextDisabled;s.title=g.oLanguage.oPaginate.sPrevious;w.title=g.oLanguage.oPaginate.sNext;m.appendChild(s);m.appendChild(w);j(s).bind("click.DT",function(){g.oApi._fnPageChange(g,"previous")&&r(g)});j(w).bind("click.DT",function(){g.oApi._fnPageChange(g,"next")&&r(g)});j(s).bind("selectstart.DT",function(){return false});j(w).bind("selectstart.DT",function(){return false});if(g.sTableId!==""&&typeof g.aanFeatures.p=="undefined"){m.setAttribute("id",
g.sTableId+"_paginate");s.setAttribute("id",g.sTableId+"_previous");w.setAttribute("id",g.sTableId+"_next")}},fnUpdate:function(g){if(g.aanFeatures.p)for(var m=g.aanFeatures.p,r=0,s=m.length;r<s;r++)if(m[r].childNodes.length!==0){m[r].childNodes[0].className=g._iDisplayStart===0?g.oClasses.sPagePrevDisabled:g.oClasses.sPagePrevEnabled;m[r].childNodes[1].className=g.fnDisplayEnd()==g.fnRecordsDisplay()?g.oClasses.sPageNextDisabled:g.oClasses.sPageNextEnabled}}},iFullNumbersShowPages:5,full_numbers:{fnInit:function(g,
m,r){var s=p.createElement("span"),w=p.createElement("span"),y=p.createElement("span"),F=p.createElement("span"),x=p.createElement("span");s.innerHTML=g.oLanguage.oPaginate.sFirst;w.innerHTML=g.oLanguage.oPaginate.sPrevious;F.innerHTML=g.oLanguage.oPaginate.sNext;x.innerHTML=g.oLanguage.oPaginate.sLast;var u=g.oClasses;s.className=u.sPageButton+" "+u.sPageFirst;w.className=u.sPageButton+" "+u.sPagePrevious;F.className=u.sPageButton+" "+u.sPageNext;x.className=u.sPageButton+" "+u.sPageLast;m.appendChild(s);
m.appendChild(w);m.appendChild(y);m.appendChild(F);m.appendChild(x);j(s).bind("click.DT",function(){g.oApi._fnPageChange(g,"first")&&r(g)});j(w).bind("click.DT",function(){g.oApi._fnPageChange(g,"previous")&&r(g)});j(F).bind("click.DT",function(){g.oApi._fnPageChange(g,"next")&&r(g)});j(x).bind("click.DT",function(){g.oApi._fnPageChange(g,"last")&&r(g)});j("span",m).bind("mousedown.DT",function(){return false}).bind("selectstart.DT",function(){return false});if(g.sTableId!==""&&typeof g.aanFeatures.p==
"undefined"){m.setAttribute("id",g.sTableId+"_paginate");s.setAttribute("id",g.sTableId+"_first");w.setAttribute("id",g.sTableId+"_previous");F.setAttribute("id",g.sTableId+"_next");x.setAttribute("id",g.sTableId+"_last")}},fnUpdate:function(g,m){if(g.aanFeatures.p){var r=n.oPagination.iFullNumbersShowPages,s=Math.floor(r/2),w=Math.ceil(g.fnRecordsDisplay()/g._iDisplayLength),y=Math.ceil(g._iDisplayStart/g._iDisplayLength)+1,F="",x,u=g.oClasses;if(w<r){s=1;x=w}else if(y<=s){s=1;x=r}else if(y>=w-s){s=
w-r+1;x=w}else{s=y-Math.ceil(r/2)+1;x=s+r-1}for(r=s;r<=x;r++)F+=y!=r?'<span class="'+u.sPageButton+'">'+r+"</span>":'<span class="'+u.sPageButtonActive+'">'+r+"</span>";x=g.aanFeatures.p;var z,U=function(){g._iDisplayStart=(this.innerHTML*1-1)*g._iDisplayLength;m(g);return false},C=function(){return false};r=0;for(s=x.length;r<s;r++)if(x[r].childNodes.length!==0){z=j("span:eq(2)",x[r]);z.html(F);j("span",z).bind("click.DT",U).bind("mousedown.DT",C).bind("selectstart.DT",C);z=x[r].getElementsByTagName("span");
z=[z[0],z[1],z[z.length-2],z[z.length-1]];j(z).removeClass(u.sPageButton+" "+u.sPageButtonActive+" "+u.sPageButtonStaticDisabled);if(y==1){z[0].className+=" "+u.sPageButtonStaticDisabled;z[1].className+=" "+u.sPageButtonStaticDisabled}else{z[0].className+=" "+u.sPageButton;z[1].className+=" "+u.sPageButton}if(w===0||y==w||g._iDisplayLength==-1){z[2].className+=" "+u.sPageButtonStaticDisabled;z[3].className+=" "+u.sPageButtonStaticDisabled}else{z[2].className+=" "+u.sPageButton;z[3].className+=" "+
u.sPageButton}}}}}};n.oSort={"string-asc":function(g,m){g=g.toLowerCase();m=m.toLowerCase();return g<m?-1:g>m?1:0},"string-desc":function(g,m){g=g.toLowerCase();m=m.toLowerCase();return g<m?1:g>m?-1:0},"html-asc":function(g,m){g=g.replace(/<.*?>/g,"").toLowerCase();m=m.replace(/<.*?>/g,"").toLowerCase();return g<m?-1:g>m?1:0},"html-desc":function(g,m){g=g.replace(/<.*?>/g,"").toLowerCase();m=m.replace(/<.*?>/g,"").toLowerCase();return g<m?1:g>m?-1:0},"date-asc":function(g,m){g=Date.parse(g);m=Date.parse(m);
if(isNaN(g)||g==="")g=Date.parse("01/01/1970 00:00:00");if(isNaN(m)||m==="")m=Date.parse("01/01/1970 00:00:00");return g-m},"date-desc":function(g,m){g=Date.parse(g);m=Date.parse(m);if(isNaN(g)||g==="")g=Date.parse("01/01/1970 00:00:00");if(isNaN(m)||m==="")m=Date.parse("01/01/1970 00:00:00");return m-g},"numeric-asc":function(g,m){return(g=="-"||g===""?0:g*1)-(m=="-"||m===""?0:m*1)},"numeric-desc":function(g,m){return(m=="-"||m===""?0:m*1)-(g=="-"||g===""?0:g*1)}};n.aTypes=[function(g){if(g.length===
0)return"numeric";var m,r=false;m=g.charAt(0);if("0123456789-".indexOf(m)==-1)return null;for(var s=1;s<g.length;s++){m=g.charAt(s);if("0123456789.".indexOf(m)==-1)return null;if(m=="."){if(r)return null;r=true}}return"numeric"},function(g){var m=Date.parse(g);if(m!==null&&!isNaN(m)||g.length===0)return"date";return null},function(g){if(g.indexOf("<")!=-1&&g.indexOf(">")!=-1)return"html";return null}];n.fnVersionCheck=function(g){var m=function(x,u){for(;x.length<u;)x+="0";return x},r=n.sVersion.split(".");
g=g.split(".");for(var s="",w="",y=0,F=g.length;y<F;y++){s+=m(r[y],3);w+=m(g[y],3)}return parseInt(s,10)>=parseInt(w,10)};n._oExternConfig={iNextUnique:0};j.fn.dataTable=function(g){function m(){this.fnRecordsTotal=function(){return this.oFeatures.bServerSide?parseInt(this._iRecordsTotal,10):this.aiDisplayMaster.length};this.fnRecordsDisplay=function(){return this.oFeatures.bServerSide?parseInt(this._iRecordsDisplay,10):this.aiDisplay.length};this.fnDisplayEnd=function(){return this.oFeatures.bServerSide?
this.oFeatures.bPaginate===false||this._iDisplayLength==-1?this._iDisplayStart+this.aiDisplay.length:Math.min(this._iDisplayStart+this._iDisplayLength,this._iRecordsDisplay):this._iDisplayEnd};this.sInstance=this.oInstance=null;this.oFeatures={bPaginate:true,bLengthChange:true,bFilter:true,bSort:true,bInfo:true,bAutoWidth:true,bProcessing:false,bSortClasses:true,bStateSave:false,bServerSide:false};this.oScroll={sX:"",sXInner:"",sY:"",bCollapse:false,bInfinite:false,iLoadGap:100,iBarWidth:0,bAutoCss:true};
this.aanFeatures=[];this.oLanguage={sProcessing:"Processing...",sLengthMenu:"Visa _MENU_ st",sZeroRecords:"Inga träffar",sEmptyTable:"inga meddelanden",sInfo:"Visar _START_ till _END_ av _TOTAL_ st",sInfoEmpty:"",sInfoFiltered:"(filtrerat från totalt _MAX_ st)",sInfoPostFix:"",sSearch:"Sök:",sUrl:"",oPaginate:{sFirst:"Första",sPrevious:"Previous",sNext:"Next",sLast:"Last"},fnInfoCallback:null};this.aoData=[];this.aiDisplay=[];this.aiDisplayMaster=
[];this.aoColumns=[];this.iNextId=0;this.asDataSearch=[];this.oPreviousSearch={sSearch:"",bRegex:false,bSmart:true};this.aoPreSearchCols=[];this.aaSorting=[[0,"asc",0]];this.aaSortingFixed=null;this.asStripClasses=[];this.asDestoryStrips=[];this.sDestroyWidth=0;this.fnFooterCallback=this.fnHeaderCallback=this.fnRowCallback=null;this.aoDrawCallback=[];this.fnInitComplete=null;this.sTableId="";this.nTableWrapper=this.nTBody=this.nTFoot=this.nTHead=this.nTable=null;this.bInitialised=false;this.aoOpenRows=
[];this.sDom="lfrtip";this.sPaginationType="two_button";this.iCookieDuration=7200;this.sCookiePrefix="SpryMedia_DataTables_";this.fnCookieCallback=null;this.aoStateSave=[];this.aoStateLoad=[];this.sAjaxSource=this.oLoadedState=null;this.bAjaxDataGet=true;this.fnServerData=function(a,b,c){j.ajax({url:a,data:b,success:c,dataType:"json",cache:false,error:function(d,f){f=="parsererror"&&alert("DataTables warning: JSON data from server could not be parsed. This is caused by a JSON formatting error.")}})};
this.fnFormatNumber=function(a){if(a<1E3)return a;else{var b=a+"";a=b.split("");var c="";b=b.length;for(var d=0;d<b;d++){if(d%3===0&&d!==0)c=","+c;c=a[b-d-1]+c}}return c};this.aLengthMenu=[10,25,50,100];this.bDrawing=this.iDraw=0;this.iDrawError=-1;this._iDisplayLength=10;this._iDisplayStart=0;this._iDisplayEnd=10;this._iRecordsDisplay=this._iRecordsTotal=0;this.bJUI=false;this.oClasses=n.oStdClasses;this.bSorted=this.bFiltered=false;this.oInit=null}function r(a){return function(){var b=[A(this[n.iApiIndex])].concat(Array.prototype.slice.call(arguments));
return n.oApi[a].apply(this,b)}}function s(a){var b,c;if(a.bInitialised===false)setTimeout(function(){s(a)},200);else{sa(a);U(a);K(a,true);a.oFeatures.bAutoWidth&&$(a);b=0;for(c=a.aoColumns.length;b<c;b++)if(a.aoColumns[b].sWidth!==null)a.aoColumns[b].nTh.style.width=v(a.aoColumns[b].sWidth);if(a.oFeatures.bSort)O(a);else{a.aiDisplay=a.aiDisplayMaster.slice();E(a);C(a)}if(a.sAjaxSource!==null&&!a.oFeatures.bServerSide)a.fnServerData.call(a.oInstance,a.sAjaxSource,[],function(d){for(b=0;b<d.aaData.length;b++)u(a,
d.aaData[b]);a.iInitDisplayStart=a._iDisplayStart;if(a.oFeatures.bSort)O(a);else{a.aiDisplay=a.aiDisplayMaster.slice();E(a);C(a)}K(a,false);w(a,d)});else if(!a.oFeatures.bServerSide){K(a,false);w(a)}}}function w(a,b){a._bInitComplete=true;if(typeof a.fnInitComplete=="function")typeof b!="undefined"?a.fnInitComplete.call(a.oInstance,a,b):a.fnInitComplete.call(a.oInstance,a)}function y(a,b,c){o(a.oLanguage,b,"sProcessing");o(a.oLanguage,b,"sLengthMenu");o(a.oLanguage,b,"sEmptyTable");o(a.oLanguage,
b,"sZeroRecords");o(a.oLanguage,b,"sInfo");o(a.oLanguage,b,"sInfoEmpty");o(a.oLanguage,b,"sInfoFiltered");o(a.oLanguage,b,"sInfoPostFix");o(a.oLanguage,b,"sSearch");if(typeof b.oPaginate!="undefined"){o(a.oLanguage.oPaginate,b.oPaginate,"sFirst");o(a.oLanguage.oPaginate,b.oPaginate,"sPrevious");o(a.oLanguage.oPaginate,b.oPaginate,"sNext");o(a.oLanguage.oPaginate,b.oPaginate,"sLast")}typeof b.sEmptyTable=="undefined"&&typeof b.sZeroRecords!="undefined"&&o(a.oLanguage,b,"sZeroRecords","sEmptyTable");
c&&s(a)}function F(a,b){a.aoColumns[a.aoColumns.length++]={sType:null,_bAutoType:true,bVisible:true,bSearchable:true,bSortable:true,asSorting:["asc","desc"],sSortingClass:a.oClasses.sSortable,sSortingClassJUI:a.oClasses.sSortJUI,sTitle:b?b.innerHTML:"",sName:"",sWidth:null,sWidthOrig:null,sClass:null,fnRender:null,bUseRendered:true,iDataSort:a.aoColumns.length-1,sSortDataType:"std",nTh:b?b:p.createElement("th"),nTf:null,anThExtra:[],anTfExtra:[]};b=a.aoColumns.length-1;if(typeof a.aoPreSearchCols[b]==
"undefined"||a.aoPreSearchCols[b]===null)a.aoPreSearchCols[b]={sSearch:"",bRegex:false,bSmart:true};else{if(typeof a.aoPreSearchCols[b].bRegex=="undefined")a.aoPreSearchCols[b].bRegex=true;if(typeof a.aoPreSearchCols[b].bSmart=="undefined")a.aoPreSearchCols[b].bSmart=true}x(a,b,null)}function x(a,b,c){b=a.aoColumns[b];if(typeof c!="undefined"&&c!==null){if(typeof c.sType!="undefined"){b.sType=c.sType;b._bAutoType=false}o(b,c,"bVisible");o(b,c,"bSearchable");o(b,c,"bSortable");o(b,c,"sTitle");o(b,
c,"sName");o(b,c,"sWidth");o(b,c,"sWidth","sWidthOrig");o(b,c,"sClass");o(b,c,"fnRender");o(b,c,"bUseRendered");o(b,c,"iDataSort");o(b,c,"asSorting");o(b,c,"sSortDataType")}if(!a.oFeatures.bSort)b.bSortable=false;if(!b.bSortable||j.inArray("asc",b.asSorting)==-1&&j.inArray("desc",b.asSorting)==-1){b.sSortingClass=a.oClasses.sSortableNone;b.sSortingClassJUI=""}else if(j.inArray("asc",b.asSorting)!=-1&&j.inArray("desc",b.asSorting)==-1){b.sSortingClass=a.oClasses.sSortableAsc;b.sSortingClassJUI=a.oClasses.sSortJUIAscAllowed}else if(j.inArray("asc",
b.asSorting)==-1&&j.inArray("desc",b.asSorting)!=-1){b.sSortingClass=a.oClasses.sSortableDesc;b.sSortingClassJUI=a.oClasses.sSortJUIDescAllowed}}function u(a,b){if(b.length!=a.aoColumns.length&&a.iDrawError!=a.iDraw){H(a,0,"Added data (size "+b.length+") does not match known number of columns ("+a.aoColumns.length+")");a.iDrawError=a.iDraw;return-1}b=b.slice();var c=a.aoData.length;a.aoData.push({nTr:p.createElement("tr"),_iId:a.iNextId++,_aData:b,_anHidden:[],_sRowStripe:""});for(var d,f,e=0;e<b.length;e++){d=
p.createElement("td");if(b[e]===null)b[e]="";if(typeof a.aoColumns[e].fnRender=="function"){f=a.aoColumns[e].fnRender({iDataRow:c,iDataColumn:e,aData:b,oSettings:a});d.innerHTML=f;if(a.aoColumns[e].bUseRendered)a.aoData[c]._aData[e]=f}else d.innerHTML=b[e];if(typeof b[e]!="string")b[e]+="";b[e]=j.trim(b[e]);if(a.aoColumns[e].sClass!==null)d.className=a.aoColumns[e].sClass;if(a.aoColumns[e]._bAutoType&&a.aoColumns[e].sType!="string"){f=aa(a.aoData[c]._aData[e]);if(a.aoColumns[e].sType===null)a.aoColumns[e].sType=
f;else if(a.aoColumns[e].sType!=f)a.aoColumns[e].sType="string"}if(a.aoColumns[e].bVisible){a.aoData[c].nTr.appendChild(d);a.aoData[c]._anHidden[e]=null}else a.aoData[c]._anHidden[e]=d}a.aiDisplayMaster.push(c);return c}function z(a){var b,c,d,f,e,i,h,k;if(a.sAjaxSource===null){h=a.nTBody.childNodes;b=0;for(c=h.length;b<c;b++)if(h[b].nodeName.toUpperCase()=="TR"){i=a.aoData.length;a.aoData.push({nTr:h[b],_iId:a.iNextId++,_aData:[],_anHidden:[],_sRowStripe:""});a.aiDisplayMaster.push(i);k=a.aoData[i]._aData;
i=h[b].childNodes;d=e=0;for(f=i.length;d<f;d++)if(i[d].nodeName.toUpperCase()=="TD"){k[e]=j.trim(i[d].innerHTML);e++}}}h=R(a);i=[];b=0;for(c=h.length;b<c;b++){d=0;for(f=h[b].childNodes.length;d<f;d++){e=h[b].childNodes[d];e.nodeName.toUpperCase()=="TD"&&i.push(e)}}i.length!=h.length*a.aoColumns.length&&H(a,1,"Unexpected number of TD elements. Expected "+h.length*a.aoColumns.length+" and got "+i.length+". DataTables does not support rowspan / colspan in the table body, and there must be one cell for each row/column combination.");
h=0;for(d=a.aoColumns.length;h<d;h++){if(a.aoColumns[h].sTitle===null)a.aoColumns[h].sTitle=a.aoColumns[h].nTh.innerHTML;f=a.aoColumns[h]._bAutoType;e=typeof a.aoColumns[h].fnRender=="function";k=a.aoColumns[h].sClass!==null;var l=a.aoColumns[h].bVisible,q,t;if(f||e||k||!l){b=0;for(c=a.aoData.length;b<c;b++){q=i[b*d+h];if(f)if(a.aoColumns[h].sType!="string"){t=aa(a.aoData[b]._aData[h]);if(a.aoColumns[h].sType===null)a.aoColumns[h].sType=t;else if(a.aoColumns[h].sType!=t)a.aoColumns[h].sType="string"}if(e){t=
a.aoColumns[h].fnRender({iDataRow:b,iDataColumn:h,aData:a.aoData[b]._aData,oSettings:a});q.innerHTML=t;if(a.aoColumns[h].bUseRendered)a.aoData[b]._aData[h]=t}if(k)q.className+=" "+a.aoColumns[h].sClass;if(l)a.aoData[b]._anHidden[h]=null;else{a.aoData[b]._anHidden[h]=q;q.parentNode.removeChild(q)}}}}}function U(a){var b,c,d,f,e,i=a.nTHead.getElementsByTagName("tr"),h=0,k;if(a.nTHead.getElementsByTagName("th").length!==0){b=0;for(d=a.aoColumns.length;b<d;b++){c=a.aoColumns[b].nTh;a.aoColumns[b].sClass!==
null&&j(c).addClass(a.aoColumns[b].sClass);f=1;for(e=i.length;f<e;f++){k=j(i[f]).children();a.aoColumns[b].anThExtra.push(k[b-h]);a.aoColumns[b].bVisible||i[f].removeChild(k[b-h])}if(a.aoColumns[b].bVisible){if(a.aoColumns[b].sTitle!=c.innerHTML)c.innerHTML=a.aoColumns[b].sTitle}else{c.parentNode.removeChild(c);h++}}}else{f=p.createElement("tr");b=0;for(d=a.aoColumns.length;b<d;b++){c=a.aoColumns[b].nTh;c.innerHTML=a.aoColumns[b].sTitle;a.aoColumns[b].sClass!==null&&j(c).addClass(a.aoColumns[b].sClass);
a.aoColumns[b].bVisible&&f.appendChild(c)}j(a.nTHead).html("")[0].appendChild(f)}if(a.bJUI){b=0;for(d=a.aoColumns.length;b<d;b++){c=a.aoColumns[b].nTh;f=p.createElement("div");f.className=a.oClasses.sSortJUIWrapper;j(c).contents().appendTo(f);f.appendChild(p.createElement("span"));c.appendChild(f)}}d=function(){this.onselectstart=function(){return false};return false};if(a.oFeatures.bSort)for(b=0;b<a.aoColumns.length;b++)if(a.aoColumns[b].bSortable!==false){ba(a,a.aoColumns[b].nTh,b);j(a.aoColumns[b].nTh).bind("mousedown.DT",
d)}else j(a.aoColumns[b].nTh).addClass(a.oClasses.sSortableNone);if(a.nTFoot!==null){h=0;i=a.nTFoot.getElementsByTagName("tr");c=i[0].getElementsByTagName("th");b=0;for(d=c.length;b<d;b++)if(typeof a.aoColumns[b]!="undefined"){a.aoColumns[b].nTf=c[b-h];if(a.oClasses.sFooterTH!=="")a.aoColumns[b].nTf.className+=" "+a.oClasses.sFooterTH;f=1;for(e=i.length;f<e;f++){k=j(i[f]).children();a.aoColumns[b].anTfExtra.push(k[b-h]);a.aoColumns[b].bVisible||i[f].removeChild(k[b-h])}if(!a.aoColumns[b].bVisible){c[b-
h].parentNode.removeChild(c[b-h]);h++}}}}function C(a){var b,c,d=[],f=0,e=false;b=a.asStripClasses.length;c=a.aoOpenRows.length;a.bDrawing=true;if(typeof a.iInitDisplayStart!="undefined"&&a.iInitDisplayStart!=-1){a._iDisplayStart=a.oFeatures.bServerSide?a.iInitDisplayStart:a.iInitDisplayStart>=a.fnRecordsDisplay()?0:a.iInitDisplayStart;a.iInitDisplayStart=-1;E(a)}if(!(!a.bDestroying&&a.oFeatures.bServerSide&&!ta(a))){a.oFeatures.bServerSide||a.iDraw++;if(a.aiDisplay.length!==0){var i=a._iDisplayStart,
h=a._iDisplayEnd;if(a.oFeatures.bServerSide){i=0;h=a.aoData.length}for(i=i;i<h;i++){var k=a.aoData[a.aiDisplay[i]],l=k.nTr;if(b!==0){var q=a.asStripClasses[f%b];if(k._sRowStripe!=q){j(l).removeClass(k._sRowStripe).addClass(q);k._sRowStripe=q}}if(typeof a.fnRowCallback=="function"){l=a.fnRowCallback.call(a.oInstance,l,a.aoData[a.aiDisplay[i]]._aData,f,i);if(!l&&!e){H(a,0,"A node was not returned by fnRowCallback");e=true}}d.push(l);f++;if(c!==0)for(k=0;k<c;k++)l==a.aoOpenRows[k].nParent&&d.push(a.aoOpenRows[k].nTr)}}else{d[0]=
p.createElement("tr");if(typeof a.asStripClasses[0]!="undefined")d[0].className=a.asStripClasses[0];e=p.createElement("td");e.setAttribute("valign","top");e.colSpan=S(a);e.className=a.oClasses.sRowEmpty;e.innerHTML=typeof a.oLanguage.sEmptyTable!="undefined"&&a.fnRecordsTotal()===0?a.oLanguage.sEmptyTable:a.oLanguage.sZeroRecords.replace("_MAX_",a.fnFormatNumber(a.fnRecordsTotal()));d[f].appendChild(e)}typeof a.fnHeaderCallback=="function"&&a.fnHeaderCallback.call(a.oInstance,j(">tr",a.nTHead)[0],
V(a),a._iDisplayStart,a.fnDisplayEnd(),a.aiDisplay);typeof a.fnFooterCallback=="function"&&a.fnFooterCallback.call(a.oInstance,j(">tr",a.nTFoot)[0],V(a),a._iDisplayStart,a.fnDisplayEnd(),a.aiDisplay);f=p.createDocumentFragment();b=p.createDocumentFragment();if(a.nTBody){e=a.nTBody.parentNode;b.appendChild(a.nTBody);if(!a.oScroll.bInfinite||!a._bInitComplete||a.bSorted||a.bFiltered){c=a.nTBody.childNodes;for(b=c.length-1;b>=0;b--)c[b].parentNode.removeChild(c[b])}b=0;for(c=d.length;b<c;b++)f.appendChild(d[b]);
a.nTBody.appendChild(f);e!==null&&e.appendChild(a.nTBody)}for(b=a.aoDrawCallback.length-1;b>=0;b--)a.aoDrawCallback[b].fn.call(a.oInstance,a);a.bSorted=false;a.bFiltered=false;a.bDrawing=false;if(a.oFeatures.bServerSide){K(a,false);typeof a._bInitComplete=="undefined"&&w(a)}}}function W(a){if(a.oFeatures.bSort)O(a,a.oPreviousSearch);else if(a.oFeatures.bFilter)P(a,a.oPreviousSearch);else{E(a);C(a)}}function ta(a){if(a.bAjaxDataGet){K(a,true);var b=a.aoColumns.length,c=[],d;a.iDraw++;c.push({name:"sEcho",
value:a.iDraw});c.push({name:"iColumns",value:b});c.push({name:"sColumns",value:ca(a)});c.push({name:"iDisplayStart",value:a._iDisplayStart});c.push({name:"iDisplayLength",value:a.oFeatures.bPaginate!==false?a._iDisplayLength:-1});if(a.oFeatures.bFilter!==false){c.push({name:"sSearch",value:a.oPreviousSearch.sSearch});c.push({name:"bRegex",value:a.oPreviousSearch.bRegex});for(d=0;d<b;d++){c.push({name:"sSearch_"+d,value:a.aoPreSearchCols[d].sSearch});c.push({name:"bRegex_"+d,value:a.aoPreSearchCols[d].bRegex});
c.push({name:"bSearchable_"+d,value:a.aoColumns[d].bSearchable})}}if(a.oFeatures.bSort!==false){var f=a.aaSortingFixed!==null?a.aaSortingFixed.length:0,e=a.aaSorting.length;c.push({name:"iSortingCols",value:f+e});for(d=0;d<f;d++){c.push({name:"iSortCol_"+d,value:a.aaSortingFixed[d][0]});c.push({name:"sSortDir_"+d,value:a.aaSortingFixed[d][1]})}for(d=0;d<e;d++){c.push({name:"iSortCol_"+(d+f),value:a.aaSorting[d][0]});c.push({name:"sSortDir_"+(d+f),value:a.aaSorting[d][1]})}for(d=0;d<b;d++)c.push({name:"bSortable_"+
d,value:a.aoColumns[d].bSortable})}a.fnServerData.call(a.oInstance,a.sAjaxSource,c,function(i){ua(a,i)});return false}else return true}function ua(a,b){if(typeof b.sEcho!="undefined")if(b.sEcho*1<a.iDraw)return;else a.iDraw=b.sEcho*1;if(!a.oScroll.bInfinite||a.oScroll.bInfinite&&(a.bSorted||a.bFiltered))da(a);a._iRecordsTotal=b.iTotalRecords;a._iRecordsDisplay=b.iTotalDisplayRecords;var c=ca(a);if(c=typeof b.sColumns!="undefined"&&c!==""&&b.sColumns!=c)var d=va(a,b.sColumns);for(var f=0,e=b.aaData.length;f<
e;f++)if(c){for(var i=[],h=0,k=a.aoColumns.length;h<k;h++)i.push(b.aaData[f][d[h]]);u(a,i)}else u(a,b.aaData[f]);a.aiDisplay=a.aiDisplayMaster.slice();a.bAjaxDataGet=false;C(a);a.bAjaxDataGet=true;K(a,false)}function sa(a){var b=p.createElement("div");a.nTable.parentNode.insertBefore(b,a.nTable);a.nTableWrapper=p.createElement("div");a.nTableWrapper.className=a.oClasses.sWrapper;a.sTableId!==""&&a.nTableWrapper.setAttribute("id",a.sTableId+"_wrapper");for(var c=a.nTableWrapper,d=a.sDom.split(""),
f,e,i,h,k,l,q,t=0;t<d.length;t++){e=0;i=d[t];if(i=="<"){h=p.createElement("div");k=d[t+1];if(k=="'"||k=='"'){l="";for(q=2;d[t+q]!=k;){l+=d[t+q];q++}if(l=="H")l="fg-toolbar ui-toolbar ui-widget-header ui-corner-tl ui-corner-tr ui-helper-clearfix";else if(l=="F")l="fg-toolbar ui-toolbar ui-widget-header ui-corner-bl ui-corner-br ui-helper-clearfix";if(l.indexOf(".")!=-1){k=l.split(".");h.setAttribute("id",k[0].substr(1,k[0].length-1));h.className=k[1]}else if(l.charAt(0)=="#")h.setAttribute("id",l.substr(1,
l.length-1));else h.className=l;t+=q}c.appendChild(h);c=h}else if(i==">")c=c.parentNode;else if(i=="l"&&a.oFeatures.bPaginate&&a.oFeatures.bLengthChange){f=wa(a);e=1}else if(i=="f"&&a.oFeatures.bFilter){f=xa(a);e=1}else if(i=="r"&&a.oFeatures.bProcessing){f=ya(a);e=1}else if(i=="t"){f=za(a);e=1}else if(i=="i"&&a.oFeatures.bInfo){f=Aa(a);e=1}else if(i=="p"&&a.oFeatures.bPaginate){f=Ba(a);e=1}else if(n.aoFeatures.length!==0){h=n.aoFeatures;q=0;for(k=h.length;q<k;q++)if(i==h[q].cFeature){if(f=h[q].fnInit(a))e=
1;break}}if(e==1&&f!==null){if(typeof a.aanFeatures[i]!="object")a.aanFeatures[i]=[];a.aanFeatures[i].push(f);c.appendChild(f)}}b.parentNode.replaceChild(a.nTableWrapper,b)}function za(a){if(a.oScroll.sX===""&&a.oScroll.sY==="")return a.nTable;var b=p.createElement("div"),c=p.createElement("div"),d=p.createElement("div"),f=p.createElement("div"),e=p.createElement("div"),i=p.createElement("div"),h=a.nTable.cloneNode(false),k=a.nTable.cloneNode(false),l=a.nTable.getElementsByTagName("thead")[0],q=a.nTable.getElementsByTagName("tfoot").length===
0?null:a.nTable.getElementsByTagName("tfoot")[0],t=typeof g.bJQueryUI!="undefined"&&g.bJQueryUI?n.oJUIClasses:n.oStdClasses;c.appendChild(d);e.appendChild(i);f.appendChild(a.nTable);b.appendChild(c);b.appendChild(f);d.appendChild(h);h.appendChild(l);if(q!==null){b.appendChild(e);i.appendChild(k);k.appendChild(q)}b.className=t.sScrollWrapper;c.className=t.sScrollHead;d.className=t.sScrollHeadInner;f.className=t.sScrollBody;e.className=t.sScrollFoot;i.className=t.sScrollFootInner;if(a.oScroll.bAutoCss){c.style.overflow=
"hidden";c.style.position="relative";e.style.overflow="hidden";f.style.overflow="auto"}c.style.border="0";c.style.width="100%";e.style.border="0";d.style.width="150%";h.removeAttribute("id");h.style.marginLeft="0";a.nTable.style.marginLeft="0";if(q!==null){k.removeAttribute("id");k.style.marginLeft="0"}d=j(">caption",a.nTable);i=0;for(k=d.length;i<k;i++)h.appendChild(d[i]);if(a.oScroll.sX!==""){c.style.width=v(a.oScroll.sX);f.style.width=v(a.oScroll.sX);if(q!==null)e.style.width=v(a.oScroll.sX);j(f).scroll(function(){c.scrollLeft=
this.scrollLeft;if(q!==null)e.scrollLeft=this.scrollLeft})}if(a.oScroll.sY!=="")f.style.height=v(a.oScroll.sY);a.aoDrawCallback.push({fn:Ca,sName:"scrolling"});a.oScroll.bInfinite&&j(f).scroll(function(){if(!a.bDrawing)if(j(this).scrollTop()+j(this).height()>j(a.nTable).height()-a.oScroll.iLoadGap)if(a.fnDisplayEnd()<a.fnRecordsDisplay()){ea(a,"next");E(a);C(a)}});a.nScrollHead=c;a.nScrollFoot=e;return b}function Ca(a){var b=a.nScrollHead.getElementsByTagName("div")[0],c=b.getElementsByTagName("table")[0],
d=a.nTable.parentNode,f,e,i,h,k,l,q,t,G=[];i=a.nTable.getElementsByTagName("thead");i.length>0&&a.nTable.removeChild(i[0]);if(a.nTFoot!==null){k=a.nTable.getElementsByTagName("tfoot");k.length>0&&a.nTable.removeChild(k[0])}i=a.nTHead.cloneNode(true);a.nTable.insertBefore(i,a.nTable.childNodes[0]);if(a.nTFoot!==null){k=a.nTFoot.cloneNode(true);a.nTable.insertBefore(k,a.nTable.childNodes[1])}var J=fa(i);f=0;for(e=J.length;f<e;f++){q=ga(a,f);J[f].style.width=a.aoColumns[q].sWidth}a.nTFoot!==null&&L(function(B){B.style.width=
""},k.getElementsByTagName("tr"));f=j(a.nTable).outerWidth();if(a.oScroll.sX===""){a.nTable.style.width="100%";if(j.browser.msie&&j.browser.version<=7)a.nTable.style.width=v(j(a.nTable).outerWidth()-a.oScroll.iBarWidth)}else if(a.oScroll.sXInner!=="")a.nTable.style.width=v(a.oScroll.sXInner);else if(f==j(d).width()&&j(d).height()<j(a.nTable).height()){a.nTable.style.width=v(f-a.oScroll.iBarWidth);if(j(a.nTable).outerWidth()>f-a.oScroll.iBarWidth)a.nTable.style.width=v(f)}else a.nTable.style.width=
v(f);f=j(a.nTable).outerWidth();e=a.nTHead.getElementsByTagName("tr");i=i.getElementsByTagName("tr");L(function(B,I){l=B.style;l.paddingTop="0";l.paddingBottom="0";l.borderTopWidth="0";l.borderBottomWidth="0";l.height=0;t=j(B).width();I.style.width=v(t);G.push(t)},i,e);j(i).height(0);if(a.nTFoot!==null){h=k.getElementsByTagName("tr");k=a.nTFoot.getElementsByTagName("tr");L(function(B,I){l=B.style;l.paddingTop="0";l.paddingBottom="0";l.borderTopWidth="0";l.borderBottomWidth="0";l.height=0;t=j(B).width();
I.style.width=v(t);G.push(t)},h,k);j(h).height(0)}L(function(B){B.innerHTML="";B.style.width=v(G.shift())},i);a.nTFoot!==null&&L(function(B){B.innerHTML="";B.style.width=v(G.shift())},h);if(j(a.nTable).outerWidth()<f)if(a.oScroll.sX==="")H(a,1,"The table cannot fit into the current element which will cause column misalignment. It is suggested that you enable x-scrolling or increase the width the table has in which to be drawn");else a.oScroll.sXInner!==""&&H(a,1,"The table cannot fit into the current element which will cause column misalignment. It is suggested that you increase the sScrollXInner property to allow it to draw in a larger area, or simply remove that parameter to allow automatic calculation");
if(a.oScroll.sY==="")if(j.browser.msie&&j.browser.version<=7)d.style.height=v(a.nTable.offsetHeight+a.oScroll.iBarWidth);if(a.oScroll.sY!==""&&a.oScroll.bCollapse){d.style.height=v(a.oScroll.sY);h=a.oScroll.sX!==""&&a.nTable.offsetWidth>d.offsetWidth?a.oScroll.iBarWidth:0;if(a.nTable.offsetHeight<d.offsetHeight)d.style.height=v(j(a.nTable).height()+h)}h=j(a.nTable).outerWidth();c.style.width=v(h);b.style.width=v(h+a.oScroll.iBarWidth);if(a.nTFoot!==null){b=a.nScrollFoot.getElementsByTagName("div")[0];
c=b.getElementsByTagName("table")[0];b.style.width=v(a.nTable.offsetWidth+a.oScroll.iBarWidth);c.style.width=v(a.nTable.offsetWidth)}if(a.bSorted||a.bFiltered)d.scrollTop=0}function X(a){if(a.oFeatures.bAutoWidth===false)return false;$(a);for(var b=0,c=a.aoColumns.length;b<c;b++)a.aoColumns[b].nTh.style.width=a.aoColumns[b].sWidth}function xa(a){var b=p.createElement("div");a.sTableId!==""&&typeof a.aanFeatures.f=="undefined"&&b.setAttribute("id",a.sTableId+"_filter");b.className=a.oClasses.sFilter;
b.innerHTML=a.oLanguage.sSearch+(a.oLanguage.sSearch===""?"":" ")+'<input type="text" />';var c=j("input",b);c.val(a.oPreviousSearch.sSearch.replace('"',"&quot;"));c.bind("keyup.DT",function(){for(var d=a.aanFeatures.f,f=0,e=d.length;f<e;f++)d[f]!=this.parentNode&&j("input",d[f]).val(this.value);this.value!=a.oPreviousSearch.sSearch&&P(a,{sSearch:this.value,bRegex:a.oPreviousSearch.bRegex,bSmart:a.oPreviousSearch.bSmart})});c.bind("keypress.DT",function(d){if(d.keyCode==13)return false});return b}
function P(a,b,c){Da(a,b.sSearch,c,b.bRegex,b.bSmart);for(b=0;b<a.aoPreSearchCols.length;b++)Ea(a,a.aoPreSearchCols[b].sSearch,b,a.aoPreSearchCols[b].bRegex,a.aoPreSearchCols[b].bSmart);n.afnFiltering.length!==0&&Fa(a);a.bFiltered=true;a._iDisplayStart=0;E(a);C(a);ha(a,0)}function Fa(a){for(var b=n.afnFiltering,c=0,d=b.length;c<d;c++)for(var f=0,e=0,i=a.aiDisplay.length;e<i;e++){var h=a.aiDisplay[e-f];if(!b[c](a,a.aoData[h]._aData,h)){a.aiDisplay.splice(e-f,1);f++}}}function Ea(a,b,c,d,f){if(b!==
""){var e=0;b=ia(b,d,f);for(d=a.aiDisplay.length-1;d>=0;d--){f=ja(a.aoData[a.aiDisplay[d]]._aData[c],a.aoColumns[c].sType);if(!b.test(f)){a.aiDisplay.splice(d,1);e++}}}}function Da(a,b,c,d,f){var e=ia(b,d,f);if(typeof c=="undefined"||c===null)c=0;if(n.afnFiltering.length!==0)c=1;if(b.length<=0){a.aiDisplay.splice(0,a.aiDisplay.length);a.aiDisplay=a.aiDisplayMaster.slice()}else if(a.aiDisplay.length==a.aiDisplayMaster.length||a.oPreviousSearch.sSearch.length>b.length||c==1||b.indexOf(a.oPreviousSearch.sSearch)!==
0){a.aiDisplay.splice(0,a.aiDisplay.length);ha(a,1);for(c=0;c<a.aiDisplayMaster.length;c++)e.test(a.asDataSearch[c])&&a.aiDisplay.push(a.aiDisplayMaster[c])}else{var i=0;for(c=0;c<a.asDataSearch.length;c++)if(!e.test(a.asDataSearch[c])){a.aiDisplay.splice(c-i,1);i++}}a.oPreviousSearch.sSearch=b;a.oPreviousSearch.bRegex=d;a.oPreviousSearch.bSmart=f}function ha(a,b){a.asDataSearch.splice(0,a.asDataSearch.length);b=typeof b!="undefined"&&b==1?a.aiDisplayMaster:a.aiDisplay;for(var c=0,d=b.length;c<d;c++)a.asDataSearch[c]=
ka(a,a.aoData[b[c]]._aData)}function ka(a,b){for(var c="",d=p.createElement("div"),f=0,e=a.aoColumns.length;f<e;f++)if(a.aoColumns[f].bSearchable)c+=ja(b[f],a.aoColumns[f].sType)+"  ";if(c.indexOf("&")!==-1){d.innerHTML=c;c=d.textContent?d.textContent:d.innerText;c=c.replace(/\n/g," ").replace(/\r/g,"")}return c}function ia(a,b,c){if(c){a=b?a.split(" "):la(a).split(" ");a="^(?=.*?"+a.join(")(?=.*?")+").*$";return new RegExp(a,"i")}else{a=b?a:la(a);return new RegExp(a,"i")}}function ja(a,b){if(typeof n.ofnSearch[b]==
"function")return n.ofnSearch[b](a);else if(b=="html")return a.replace(/\n/g," ").replace(/<.*?>/g,"");else if(typeof a=="string")return a.replace(/\n/g," ");return a}function O(a,b){var c,d,f,e,i,h,k=[],l=[],q=n.oSort,t=a.aoData,G=a.aoColumns;if(!a.oFeatures.bServerSide&&(a.aaSorting.length!==0||a.aaSortingFixed!==null)){k=a.aaSortingFixed!==null?a.aaSortingFixed.concat(a.aaSorting):a.aaSorting.slice();for(f=0;f<k.length;f++){e=k[f][0];i=M(a,e);h=a.aoColumns[e].sSortDataType;if(typeof n.afnSortData[h]!=
"undefined"){var J=n.afnSortData[h](a,e,i);i=0;for(h=t.length;i<h;i++)t[i]._aData[e]=J[i]}}f=0;for(e=a.aiDisplayMaster.length;f<e;f++)l[a.aiDisplayMaster[f]]=f;var B=k.length;a.aiDisplayMaster.sort(function(I,Y){var N;for(f=0;f<B;f++){c=G[k[f][0]].iDataSort;d=G[c].sType;N=q[d+"-"+k[f][1]](t[I]._aData[c],t[Y]._aData[c]);if(N!==0)return N}return q["numeric-asc"](l[I],l[Y])})}if(typeof b=="undefined"||b)T(a);a.bSorted=true;if(a.oFeatures.bFilter)P(a,a.oPreviousSearch,1);else{a.aiDisplay=a.aiDisplayMaster.slice();
a._iDisplayStart=0;E(a);C(a)}}function ba(a,b,c,d){j(b).bind("click.DT",function(f){if(a.aoColumns[c].bSortable!==false){var e=function(){var i,h;if(f.shiftKey){for(var k=false,l=0;l<a.aaSorting.length;l++)if(a.aaSorting[l][0]==c){k=true;i=a.aaSorting[l][0];h=a.aaSorting[l][2]+1;if(typeof a.aoColumns[i].asSorting[h]=="undefined")a.aaSorting.splice(l,1);else{a.aaSorting[l][1]=a.aoColumns[i].asSorting[h];a.aaSorting[l][2]=h}break}k===false&&a.aaSorting.push([c,a.aoColumns[c].asSorting[0],0])}else if(a.aaSorting.length==
1&&a.aaSorting[0][0]==c){i=a.aaSorting[0][0];h=a.aaSorting[0][2]+1;if(typeof a.aoColumns[i].asSorting[h]=="undefined")h=0;a.aaSorting[0][1]=a.aoColumns[i].asSorting[h];a.aaSorting[0][2]=h}else{a.aaSorting.splice(0,a.aaSorting.length);a.aaSorting.push([c,a.aoColumns[c].asSorting[0],0])}O(a)};if(a.oFeatures.bProcessing){K(a,true);setTimeout(function(){e();a.oFeatures.bServerSide||K(a,false)},0)}else e();typeof d=="function"&&d(a)}})}function T(a){var b,c,d,f,e,i=a.aoColumns.length,h=a.oClasses;for(b=
0;b<i;b++)a.aoColumns[b].bSortable&&j(a.aoColumns[b].nTh).removeClass(h.sSortAsc+" "+h.sSortDesc+" "+a.aoColumns[b].sSortingClass);f=a.aaSortingFixed!==null?a.aaSortingFixed.concat(a.aaSorting):a.aaSorting.slice();for(b=0;b<a.aoColumns.length;b++)if(a.aoColumns[b].bSortable){e=a.aoColumns[b].sSortingClass;d=-1;for(c=0;c<f.length;c++)if(f[c][0]==b){e=f[c][1]=="asc"?h.sSortAsc:h.sSortDesc;d=c;break}j(a.aoColumns[b].nTh).addClass(e);if(a.bJUI){c=j("span",a.aoColumns[b].nTh);c.removeClass(h.sSortJUIAsc+
" "+h.sSortJUIDesc+" "+h.sSortJUI+" "+h.sSortJUIAscAllowed+" "+h.sSortJUIDescAllowed);c.addClass(d==-1?a.aoColumns[b].sSortingClassJUI:f[d][1]=="asc"?h.sSortJUIAsc:h.sSortJUIDesc)}}else j(a.aoColumns[b].nTh).addClass(a.aoColumns[b].sSortingClass);e=h.sSortColumn;if(a.oFeatures.bSort&&a.oFeatures.bSortClasses){d=Z(a);if(d.length>=i)for(b=0;b<i;b++)if(d[b].className.indexOf(e+"1")!=-1){c=0;for(a=d.length/i;c<a;c++)d[i*c+b].className=j.trim(d[i*c+b].className.replace(e+"1",""))}else if(d[b].className.indexOf(e+
"2")!=-1){c=0;for(a=d.length/i;c<a;c++)d[i*c+b].className=j.trim(d[i*c+b].className.replace(e+"2",""))}else if(d[b].className.indexOf(e+"3")!=-1){c=0;for(a=d.length/i;c<a;c++)d[i*c+b].className=j.trim(d[i*c+b].className.replace(" "+e+"3",""))}h=1;var k;for(b=0;b<f.length;b++){k=parseInt(f[b][0],10);c=0;for(a=d.length/i;c<a;c++)d[i*c+k].className+=" "+e+h;h<3&&h++}}}function Ba(a){if(a.oScroll.bInfinite)return null;var b=p.createElement("div");b.className=a.oClasses.sPaging+a.sPaginationType;n.oPagination[a.sPaginationType].fnInit(a,
b,function(c){E(c);C(c)});typeof a.aanFeatures.p=="undefined"&&a.aoDrawCallback.push({fn:function(c){n.oPagination[c.sPaginationType].fnUpdate(c,function(d){E(d);C(d)})},sName:"pagination"});return b}function ea(a,b){var c=a._iDisplayStart;if(b=="first")a._iDisplayStart=0;else if(b=="previous"){a._iDisplayStart=a._iDisplayLength>=0?a._iDisplayStart-a._iDisplayLength:0;if(a._iDisplayStart<0)a._iDisplayStart=0}else if(b=="next")if(a._iDisplayLength>=0){if(a._iDisplayStart+a._iDisplayLength<a.fnRecordsDisplay())a._iDisplayStart+=
a._iDisplayLength}else a._iDisplayStart=0;else if(b=="last")if(a._iDisplayLength>=0){b=parseInt((a.fnRecordsDisplay()-1)/a._iDisplayLength,10)+1;a._iDisplayStart=(b-1)*a._iDisplayLength}else a._iDisplayStart=0;else H(a,0,"Unknown paging action: "+b);return c!=a._iDisplayStart}function Aa(a){var b=p.createElement("div");b.className=a.oClasses.sInfo;if(typeof a.aanFeatures.i=="undefined"){a.aoDrawCallback.push({fn:Ga,sName:"information"});a.sTableId!==""&&b.setAttribute("id",a.sTableId+"_info")}return b}
function Ga(a){if(!(!a.oFeatures.bInfo||a.aanFeatures.i.length===0)){var b=a._iDisplayStart+1,c=a.fnDisplayEnd(),d=a.fnRecordsTotal(),f=a.fnRecordsDisplay(),e=a.fnFormatNumber(b),i=a.fnFormatNumber(c),h=a.fnFormatNumber(d),k=a.fnFormatNumber(f);if(a.oScroll.bInfinite)e=a.fnFormatNumber(1);e=a.fnRecordsDisplay()===0&&a.fnRecordsDisplay()==a.fnRecordsTotal()?a.oLanguage.sInfoEmpty+a.oLanguage.sInfoPostFix:a.fnRecordsDisplay()===0?a.oLanguage.sInfoEmpty+" "+a.oLanguage.sInfoFiltered.replace("_MAX_",
h)+a.oLanguage.sInfoPostFix:a.fnRecordsDisplay()==a.fnRecordsTotal()?a.oLanguage.sInfo.replace("_START_",e).replace("_END_",i).replace("_TOTAL_",k)+a.oLanguage.sInfoPostFix:a.oLanguage.sInfo.replace("_START_",e).replace("_END_",i).replace("_TOTAL_",k)+" "+a.oLanguage.sInfoFiltered.replace("_MAX_",a.fnFormatNumber(a.fnRecordsTotal()))+a.oLanguage.sInfoPostFix;if(a.oLanguage.fnInfoCallback!==null)e=a.oLanguage.fnInfoCallback(a,b,c,d,f,e);a=a.aanFeatures.i;b=0;for(c=a.length;b<c;b++)j(a[b]).html(e)}}
function wa(a){if(a.oScroll.bInfinite)return null;var b='<select size="1" '+(a.sTableId===""?"":'name="'+a.sTableId+'_length"')+">",c,d;if(a.aLengthMenu.length==2&&typeof a.aLengthMenu[0]=="object"&&typeof a.aLengthMenu[1]=="object"){c=0;for(d=a.aLengthMenu[0].length;c<d;c++)b+='<option value="'+a.aLengthMenu[0][c]+'">'+a.aLengthMenu[1][c]+"</option>"}else{c=0;for(d=a.aLengthMenu.length;c<d;c++)b+='<option value="'+a.aLengthMenu[c]+'">'+a.aLengthMenu[c]+"</option>"}b+="</select>";var f=p.createElement("div");
a.sTableId!==""&&typeof a.aanFeatures.l=="undefined"&&f.setAttribute("id",a.sTableId+"_length");f.className=a.oClasses.sLength;f.innerHTML=a.oLanguage.sLengthMenu.replace("_MENU_",b);j('select option[value="'+a._iDisplayLength+'"]',f).attr("selected",true);j("select",f).bind("change.DT",function(){var e=j(this).val(),i=a.aanFeatures.l;c=0;for(d=i.length;c<d;c++)i[c]!=this.parentNode&&j("select",i[c]).val(e);a._iDisplayLength=parseInt(e,10);E(a);if(a.fnDisplayEnd()==a.fnRecordsDisplay()){a._iDisplayStart=
a.fnDisplayEnd()-a._iDisplayLength;if(a._iDisplayStart<0)a._iDisplayStart=0}if(a._iDisplayLength==-1)a._iDisplayStart=0;C(a)});return f}function ya(a){var b=p.createElement("div");a.sTableId!==""&&typeof a.aanFeatures.r=="undefined"&&b.setAttribute("id",a.sTableId+"_processing");b.innerHTML=a.oLanguage.sProcessing;b.className=a.oClasses.sProcessing;a.nTable.parentNode.insertBefore(b,a.nTable);return b}function K(a,b){if(a.oFeatures.bProcessing){a=a.aanFeatures.r;for(var c=0,d=a.length;c<d;c++)a[c].style.visibility=
b?"visible":"hidden"}}function ga(a,b){for(var c=-1,d=0;d<a.aoColumns.length;d++){a.aoColumns[d].bVisible===true&&c++;if(c==b)return d}return null}function M(a,b){for(var c=-1,d=0;d<a.aoColumns.length;d++){a.aoColumns[d].bVisible===true&&c++;if(d==b)return a.aoColumns[d].bVisible===true?c:null}return null}function Q(a,b){var c,d;c=a._iDisplayStart;for(d=a._iDisplayEnd;c<d;c++)if(a.aoData[a.aiDisplay[c]].nTr==b)return a.aiDisplay[c];c=0;for(d=a.aoData.length;c<d;c++)if(a.aoData[c].nTr==b)return c;
return null}function S(a){for(var b=0,c=0;c<a.aoColumns.length;c++)a.aoColumns[c].bVisible===true&&b++;return b}function E(a){a._iDisplayEnd=a.oFeatures.bPaginate===false?a.aiDisplay.length:a._iDisplayStart+a._iDisplayLength>a.aiDisplay.length||a._iDisplayLength==-1?a.aiDisplay.length:a._iDisplayStart+a._iDisplayLength}function Ha(a,b){if(!a||a===null||a==="")return 0;if(typeof b=="undefined")b=p.getElementsByTagName("body")[0];var c=p.createElement("div");c.style.width=a;b.appendChild(c);a=c.offsetWidth;
b.removeChild(c);return a}function $(a){var b=0,c,d=0,f=a.aoColumns.length,e,i=j("th",a.nTHead);for(e=0;e<f;e++)if(a.aoColumns[e].bVisible){d++;if(a.aoColumns[e].sWidth!==null){c=Ha(a.aoColumns[e].sWidthOrig,a.nTable.parentNode);if(c!==null)a.aoColumns[e].sWidth=v(c);b++}}if(f==i.length&&b===0&&d==f&&a.oScroll.sX===""&&a.oScroll.sY==="")for(e=0;e<a.aoColumns.length;e++){c=j(i[e]).width();if(c!==null)a.aoColumns[e].sWidth=v(c)}else{b=a.nTable.cloneNode(false);e=p.createElement("tbody");c=p.createElement("tr");
b.removeAttribute("id");b.appendChild(a.nTHead.cloneNode(true));if(a.nTFoot!==null){b.appendChild(a.nTFoot.cloneNode(true));L(function(h){h.style.width=""},b.getElementsByTagName("tr"))}b.appendChild(e);e.appendChild(c);e=j("thead th",b);if(e.length===0)e=j("tbody tr:eq(0)>td",b);e.each(function(h){this.style.width="";h=ga(a,h);if(h!==null&&a.aoColumns[h].sWidthOrig!=="")this.style.width=a.aoColumns[h].sWidthOrig});for(e=0;e<f;e++)if(a.aoColumns[e].bVisible){d=Ia(a,e);if(d!==null){d=d.cloneNode(true);
c.appendChild(d)}}e=a.nTable.parentNode;e.appendChild(b);if(a.oScroll.sX!==""&&a.oScroll.sXInner!=="")b.style.width=v(a.oScroll.sXInner);else if(a.oScroll.sX!==""){b.style.width="";if(j(b).width()<e.offsetWidth)b.style.width=v(e.offsetWidth)}else if(a.oScroll.sY!=="")b.style.width=v(e.offsetWidth);b.style.visibility="hidden";Ja(a,b);f=j("tbody tr:eq(0)>td",b);if(f.length===0)f=j("thead tr:eq(0)>th",b);for(e=c=0;e<a.aoColumns.length;e++)if(a.aoColumns[e].bVisible){d=j(f[c]).outerWidth();if(d!==null&&
d>0)a.aoColumns[e].sWidth=v(d);c++}a.nTable.style.width=v(j(b).outerWidth());b.parentNode.removeChild(b)}}function Ja(a,b){if(a.oScroll.sX===""&&a.oScroll.sY!==""){j(b).width();b.style.width=v(j(b).outerWidth()-a.oScroll.iBarWidth)}else if(a.oScroll.sX!=="")b.style.width=v(j(b).outerWidth())}function Ia(a,b,c){if(typeof c=="undefined"||c){c=Ka(a,b);b=M(a,b);if(c<0)return null;return a.aoData[c].nTr.getElementsByTagName("td")[b]}var d=-1,f,e;c=-1;var i=p.createElement("div");i.style.visibility="hidden";
i.style.position="absolute";p.body.appendChild(i);f=0;for(e=a.aoData.length;f<e;f++){i.innerHTML=a.aoData[f]._aData[b];if(i.offsetWidth>d){d=i.offsetWidth;c=f}}p.body.removeChild(i);if(c>=0){b=M(a,b);if(a=a.aoData[c].nTr.getElementsByTagName("td")[b])return a}return null}function Ka(a,b){for(var c=-1,d=-1,f=0;f<a.aoData.length;f++){var e=a.aoData[f]._aData[b];if(e.length>c){c=e.length;d=f}}return d}function v(a){if(a===null)return"0px";if(typeof a=="number"){if(a<0)return"0px";return a+"px"}var b=
a.charCodeAt(a.length-1);if(b<48||b>57)return a;return a+"px"}function Oa(a,b){if(a.length!=b.length)return 1;for(var c=0;c<a.length;c++)if(a[c]!=b[c])return 2;return 0}function aa(a){for(var b=n.aTypes,c=b.length,d=0;d<c;d++){var f=b[d](a);if(f!==null)return f}return"string"}function A(a){for(var b=0;b<D.length;b++)if(D[b].nTable==a)return D[b];return null}function V(a){for(var b=[],c=a.aoData.length,d=0;d<c;d++)b.push(a.aoData[d]._aData);return b}function R(a){for(var b=[],c=a.aoData.length,d=0;d<
c;d++)b.push(a.aoData[d].nTr);return b}function Z(a){var b=R(a),c=[],d,f=[],e,i,h,k;e=0;for(i=b.length;e<i;e++){c=[];h=0;for(k=b[e].childNodes.length;h<k;h++){d=b[e].childNodes[h];d.nodeName.toUpperCase()=="TD"&&c.push(d)}h=d=0;for(k=a.aoColumns.length;h<k;h++)if(a.aoColumns[h].bVisible)f.push(c[h-d]);else{f.push(a.aoData[e]._anHidden[h]);d++}}return f}function la(a){return a.replace(new RegExp("(\\/|\\.|\\*|\\+|\\?|\\||\\(|\\)|\\[|\\]|\\{|\\}|\\\\|\\$|\\^)","g"),"\\$1")}function ma(a,b){for(var c=
-1,d=0,f=a.length;d<f;d++)if(a[d]==b)c=d;else a[d]>b&&a[d]--;c!=-1&&a.splice(c,1)}function va(a,b){b=b.split(",");for(var c=[],d=0,f=a.aoColumns.length;d<f;d++)for(var e=0;e<f;e++)if(a.aoColumns[d].sName==b[e]){c.push(e);break}return c}function ca(a){for(var b="",c=0,d=a.aoColumns.length;c<d;c++)b+=a.aoColumns[c].sName+",";if(b.length==d)return"";return b.slice(0,-1)}function H(a,b,c){a=a.sTableId===""?"DataTables warning: "+c:"DataTables warning (table id = '"+a.sTableId+"'): "+c;if(b===0)if(n.sErrMode==
"alert")alert(a);else throw a;else typeof console!="undefined"&&typeof console.log!="undefined"&&console.log(a)}function da(a){a.aoData.splice(0,a.aoData.length);a.aiDisplayMaster.splice(0,a.aiDisplayMaster.length);a.aiDisplay.splice(0,a.aiDisplay.length);E(a)}function na(a){if(!(!a.oFeatures.bStateSave||typeof a.bDestroying!="undefined")){var b,c,d,f="{";f+='"iCreate":'+(new Date).getTime()+",";f+='"iStart":'+a._iDisplayStart+",";f+='"iEnd":'+a._iDisplayEnd+",";f+='"iLength":'+a._iDisplayLength+
",";f+='"sFilter":"'+encodeURIComponent(a.oPreviousSearch.sSearch)+'",';f+='"sFilterEsc":'+!a.oPreviousSearch.bRegex+",";f+='"aaSorting":[ ';for(b=0;b<a.aaSorting.length;b++)f+="["+a.aaSorting[b][0]+',"'+a.aaSorting[b][1]+'"],';f=f.substring(0,f.length-1);f+="],";f+='"aaSearchCols":[ ';for(b=0;b<a.aoPreSearchCols.length;b++)f+='["'+encodeURIComponent(a.aoPreSearchCols[b].sSearch)+'",'+!a.aoPreSearchCols[b].bRegex+"],";f=f.substring(0,f.length-1);f+="],";f+='"abVisCols":[ ';for(b=0;b<a.aoColumns.length;b++)f+=
a.aoColumns[b].bVisible+",";f=f.substring(0,f.length-1);f+="]";b=0;for(c=a.aoStateSave.length;b<c;b++){d=a.aoStateSave[b].fn(a,f);if(d!=="")f=d}f+="}";La(a.sCookiePrefix+a.sInstance,f,a.iCookieDuration,a.sCookiePrefix,a.fnCookieCallback)}}function Ma(a,b){if(a.oFeatures.bStateSave){var c,d,f;d=oa(a.sCookiePrefix+a.sInstance);if(d!==null&&d!==""){try{c=typeof j.parseJSON=="function"?j.parseJSON(d.replace(/'/g,'"')):eval("("+d+")")}catch(e){return}d=0;for(f=a.aoStateLoad.length;d<f;d++)if(!a.aoStateLoad[d].fn(a,
c))return;a.oLoadedState=j.extend(true,{},c);a._iDisplayStart=c.iStart;a.iInitDisplayStart=c.iStart;a._iDisplayEnd=c.iEnd;a._iDisplayLength=c.iLength;a.oPreviousSearch.sSearch=decodeURIComponent(c.sFilter);a.aaSorting=c.aaSorting.slice();a.saved_aaSorting=c.aaSorting.slice();if(typeof c.sFilterEsc!="undefined")a.oPreviousSearch.bRegex=!c.sFilterEsc;if(typeof c.aaSearchCols!="undefined")for(d=0;d<c.aaSearchCols.length;d++)a.aoPreSearchCols[d]={sSearch:decodeURIComponent(c.aaSearchCols[d][0]),bRegex:!c.aaSearchCols[d][1]};
if(typeof c.abVisCols!="undefined"){b.saved_aoColumns=[];for(d=0;d<c.abVisCols.length;d++){b.saved_aoColumns[d]={};b.saved_aoColumns[d].bVisible=c.abVisCols[d]}}}}}function La(a,b,c,d,f){var e=new Date;e.setTime(e.getTime()+c*1E3);c=ra.location.pathname.split("/");a=a+"_"+c.pop().replace(/[\/:]/g,"").toLowerCase();var i;if(f!==null){i=typeof j.parseJSON=="function"?j.parseJSON(b):eval("("+b+")");b=f(a,i,e.toGMTString(),c.join("/")+"/")}else b=a+"="+encodeURIComponent(b)+"; expires="+e.toGMTString()+
"; path="+c.join("/")+"/";f="";e=9999999999999;if((oa(a)!==null?p.cookie.length:b.length+p.cookie.length)+10>4096){a=p.cookie.split(";");for(var h=0,k=a.length;h<k;h++)if(a[h].indexOf(d)!=-1){var l=a[h].split("=");try{i=eval("("+decodeURIComponent(l[1])+")")}catch(q){continue}if(typeof i.iCreate!="undefined"&&i.iCreate<e){f=l[0];e=i.iCreate}}if(f!=="")p.cookie=f+"=; expires=Thu, 01-Jan-1970 00:00:01 GMT; path="+c.join("/")+"/"}p.cookie=b}function oa(a){var b=ra.location.pathname.split("/");a=a+"_"+
b[b.length-1].replace(/[\/:]/g,"").toLowerCase()+"=";b=p.cookie.split(";");for(var c=0;c<b.length;c++){for(var d=b[c];d.charAt(0)==" ";)d=d.substring(1,d.length);if(d.indexOf(a)===0)return decodeURIComponent(d.substring(a.length,d.length))}return null}function fa(a){a=a.getElementsByTagName("tr");if(a.length==1)return a[0].getElementsByTagName("th");var b=[],c=[],d,f,e,i,h,k,l=function(I,Y,N){for(;typeof I[Y][N]!="undefined";)N++;return N},q=function(I){if(typeof b[I]=="undefined")b[I]=[]};d=0;for(i=
a.length;d<i;d++){q(d);var t=0,G=[];f=0;for(h=a[d].childNodes.length;f<h;f++)if(a[d].childNodes[f].nodeName.toUpperCase()=="TD"||a[d].childNodes[f].nodeName.toUpperCase()=="TH")G.push(a[d].childNodes[f]);f=0;for(h=G.length;f<h;f++){var J=G[f].getAttribute("colspan")*1,B=G[f].getAttribute("rowspan")*1;if(!J||J===0||J===1){k=l(b,d,t);b[d][k]=G[f].nodeName.toUpperCase()=="TD"?4:G[f];if(B||B===0||B===1)for(e=1;e<B;e++){q(d+e);b[d+e][k]=2}t++}else{k=l(b,d,t);for(e=0;e<J;e++)b[d][k+e]=3;t+=J}}}d=0;for(i=
b.length;d<i;d++){f=0;for(h=b[d].length;f<h;f++)if(typeof b[d][f]=="object"&&typeof c[f]=="undefined")c[f]=b[d][f]}return c}function Na(){var a=p.createElement("p"),b=a.style;b.width="100%";b.height="200px";var c=p.createElement("div");b=c.style;b.position="absolute";b.top="0px";b.left="0px";b.visibility="hidden";b.width="200px";b.height="150px";b.overflow="hidden";c.appendChild(a);p.body.appendChild(c);b=a.offsetWidth;c.style.overflow="scroll";a=a.offsetWidth;if(b==a)a=c.clientWidth;p.body.removeChild(c);
return b-a}function L(a,b,c){for(var d=0,f=b.length;d<f;d++)for(var e=0,i=b[d].childNodes.length;e<i;e++)if(b[d].childNodes[e].nodeType==1)typeof c!="undefined"?a(b[d].childNodes[e],c[d].childNodes[e]):a(b[d].childNodes[e])}function o(a,b,c,d){if(typeof d=="undefined")d=c;if(typeof b[c]!="undefined")a[d]=b[c]}this.oApi={};this.fnDraw=function(a){var b=A(this[n.iApiIndex]);if(typeof a!="undefined"&&a===false){E(b);C(b)}else W(b)};this.fnFilter=function(a,b,c,d,f){var e=A(this[n.iApiIndex]);if(e.oFeatures.bFilter){if(typeof c==
"undefined")c=false;if(typeof d=="undefined")d=true;if(typeof f=="undefined")f=true;if(typeof b=="undefined"||b===null){P(e,{sSearch:a,bRegex:c,bSmart:d},1);if(f&&typeof e.aanFeatures.f!="undefined"){b=e.aanFeatures.f;c=0;for(d=b.length;c<d;c++)j("input",b[c]).val(a)}}else{e.aoPreSearchCols[b].sSearch=a;e.aoPreSearchCols[b].bRegex=c;e.aoPreSearchCols[b].bSmart=d;P(e,e.oPreviousSearch,1)}}};this.fnSettings=function(){return A(this[n.iApiIndex])};this.fnVersionCheck=n.fnVersionCheck;this.fnSort=function(a){var b=
A(this[n.iApiIndex]);b.aaSorting=a;O(b)};this.fnSortListener=function(a,b,c){ba(A(this[n.iApiIndex]),a,b,c)};this.fnAddData=function(a,b){if(a.length===0)return[];var c=[],d,f=A(this[n.iApiIndex]);if(typeof a[0]=="object")for(var e=0;e<a.length;e++){d=u(f,a[e]);if(d==-1)return c;c.push(d)}else{d=u(f,a);if(d==-1)return c;c.push(d)}f.aiDisplay=f.aiDisplayMaster.slice();if(typeof b=="undefined"||b)W(f);return c};this.fnDeleteRow=function(a,b,c){var d=A(this[n.iApiIndex]);a=typeof a=="object"?Q(d,a):
a;var f=d.aoData.splice(a,1),e=j.inArray(a,d.aiDisplay);d.asDataSearch.splice(e,1);ma(d.aiDisplayMaster,a);ma(d.aiDisplay,a);typeof b=="function"&&b.call(this,d,f);if(d._iDisplayStart>=d.aiDisplay.length){d._iDisplayStart-=d._iDisplayLength;if(d._iDisplayStart<0)d._iDisplayStart=0}if(typeof c=="undefined"||c){E(d);C(d)}return f};this.fnClearTable=function(a){var b=A(this[n.iApiIndex]);da(b);if(typeof a=="undefined"||a)C(b)};this.fnOpen=function(a,b,c){var d=A(this[n.iApiIndex]);this.fnClose(a);var f=
p.createElement("tr"),e=p.createElement("td");f.appendChild(e);e.className=c;e.colSpan=S(d);e.innerHTML=b;b=j("tr",d.nTBody);j.inArray(a,b)!=-1&&j(f).insertAfter(a);d.aoOpenRows.push({nTr:f,nParent:a});return f};this.fnClose=function(a){for(var b=A(this[n.iApiIndex]),c=0;c<b.aoOpenRows.length;c++)if(b.aoOpenRows[c].nParent==a){(a=b.aoOpenRows[c].nTr.parentNode)&&a.removeChild(b.aoOpenRows[c].nTr);b.aoOpenRows.splice(c,1);return 0}return 1};this.fnGetData=function(a){var b=A(this[n.iApiIndex]);if(typeof a!=
"undefined"){a=typeof a=="object"?Q(b,a):a;return(aRowData=b.aoData[a])?aRowData._aData:null}return V(b)};this.fnGetNodes=function(a){var b=A(this[n.iApiIndex]);if(typeof a!="undefined")return(aRowData=b.aoData[a])?aRowData.nTr:null;return R(b)};this.fnGetPosition=function(a){var b=A(this[n.iApiIndex]);if(a.nodeName.toUpperCase()=="TR")return Q(b,a);else if(a.nodeName.toUpperCase()=="TD")for(var c=Q(b,a.parentNode),d=0,f=0;f<b.aoColumns.length;f++)if(b.aoColumns[f].bVisible){if(b.aoData[c].nTr.getElementsByTagName("td")[f-
d]==a)return[c,f-d,f]}else d++;return null};this.fnUpdate=function(a,b,c,d,f){var e=A(this[n.iApiIndex]),i,h;b=typeof b=="object"?Q(e,b):b;if(typeof a!="object"){h=a;e.aoData[b]._aData[c]=h;if(e.aoColumns[c].fnRender!==null){h=e.aoColumns[c].fnRender({iDataRow:b,iDataColumn:c,aData:e.aoData[b]._aData,oSettings:e});if(e.aoColumns[c].bUseRendered)e.aoData[b]._aData[c]=h}i=M(e,c);if(i!==null)e.aoData[b].nTr.getElementsByTagName("td")[i].innerHTML=h;else e.aoData[b]._anHidden[c].innerHTML=h}else{if(a.length!=
e.aoColumns.length){H(e,0,"An array passed to fnUpdate must have the same number of columns as the table in question - in this case "+e.aoColumns.length);return 1}for(c=0;c<a.length;c++){h=a[c];e.aoData[b]._aData[c]=h;if(e.aoColumns[c].fnRender!==null){h=e.aoColumns[c].fnRender({iDataRow:b,iDataColumn:c,aData:e.aoData[b]._aData,oSettings:e});if(e.aoColumns[c].bUseRendered)e.aoData[b]._aData[c]=h}i=M(e,c);if(i!==null)e.aoData[b].nTr.getElementsByTagName("td")[i].innerHTML=h;else e.aoData[b]._anHidden[c].innerHTML=
h}}a=j.inArray(b,e.aiDisplay);e.asDataSearch[a]=ka(e,e.aoData[b]._aData);if(typeof f=="undefined"||f)X(e);if(typeof d=="undefined"||d)W(e);return 0};this.fnSetColumnVis=function(a,b,c){var d=A(this[n.iApiIndex]),f,e;e=d.aoColumns.length;var i,h,k,l,q;if(d.aoColumns[a].bVisible!=b){l=j(">tr",d.nTHead)[0];i=j(">tr",d.nTFoot)[0];q=[];h=[];for(f=0;f<e;f++){q.push(d.aoColumns[f].nTh);h.push(d.aoColumns[f].nTf)}if(b){for(f=b=0;f<a;f++)d.aoColumns[f].bVisible&&b++;if(b>=S(d)){l.appendChild(q[a]);l=j(">tr",
d.nTHead);f=1;for(e=l.length;f<e;f++)l[f].appendChild(d.aoColumns[a].anThExtra[f-1]);if(i){i.appendChild(h[a]);l=j(">tr",d.nTFoot);f=1;for(e=l.length;f<e;f++)l[f].appendChild(d.aoColumns[a].anTfExtra[f-1])}f=0;for(e=d.aoData.length;f<e;f++){i=d.aoData[f]._anHidden[a];d.aoData[f].nTr.appendChild(i)}}else{for(f=a;f<e;f++){k=M(d,f);if(k!==null)break}l.insertBefore(q[a],l.getElementsByTagName("th")[k]);l=j(">tr",d.nTHead);f=1;for(e=l.length;f<e;f++){q=j(l[f]).children();l[f].insertBefore(d.aoColumns[a].anThExtra[f-
1],q[k])}if(i){i.insertBefore(h[a],i.getElementsByTagName("th")[k]);l=j(">tr",d.nTFoot);f=1;for(e=l.length;f<e;f++){q=j(l[f]).children();l[f].insertBefore(d.aoColumns[a].anTfExtra[f-1],q[k])}}Z(d);f=0;for(e=d.aoData.length;f<e;f++){i=d.aoData[f]._anHidden[a];d.aoData[f].nTr.insertBefore(i,j(">td:eq("+k+")",d.aoData[f].nTr)[0])}}d.aoColumns[a].bVisible=true}else{l.removeChild(q[a]);f=0;for(e=d.aoColumns[a].anThExtra.length;f<e;f++){k=d.aoColumns[a].anThExtra[f];k.parentNode.removeChild(k)}if(i){i.removeChild(h[a]);
f=0;for(e=d.aoColumns[a].anTfExtra.length;f<e;f++){k=d.aoColumns[a].anTfExtra[f];k.parentNode.removeChild(k)}}h=Z(d);f=0;for(e=d.aoData.length;f<e;f++){i=h[f*d.aoColumns.length+a*1];d.aoData[f]._anHidden[a]=i;i.parentNode.removeChild(i)}d.aoColumns[a].bVisible=false}f=0;for(e=d.aoOpenRows.length;f<e;f++)d.aoOpenRows[f].nTr.colSpan=S(d);if(typeof c=="undefined"||c){X(d);C(d)}na(d)}};this.fnPageChange=function(a,b){var c=A(this[n.iApiIndex]);ea(c,a);E(c);if(typeof b=="undefined"||b)C(c)};this.fnDestroy=
function(){var a=A(this[n.iApiIndex]),b=a.nTableWrapper.parentNode,c=a.nTBody,d,f;a.bDestroying=true;j(a.nTableWrapper).find("*").andSelf().unbind(".DT");d=0;for(f=a.aoColumns.length;d<f;d++)a.aoColumns[d].bVisible===false&&this.fnSetColumnVis(d,true);j("tbody>tr>td."+a.oClasses.sRowEmpty,a.nTable).parent().remove();if(a.nTable!=a.nTHead.parentNode){j(">thead",a.nTable).remove();a.nTable.appendChild(a.nTHead)}if(a.nTFoot&&a.nTable!=a.nTFoot.parentNode){j(">tfoot",a.nTable).remove();a.nTable.appendChild(a.nTFoot)}a.nTable.parentNode.removeChild(a.nTable);
j(a.nTableWrapper).remove();a.aaSorting=[];a.aaSortingFixed=[];T(a);j(R(a)).removeClass(a.asStripClasses.join(" "));if(a.bJUI){j("th",a.nTHead).removeClass([n.oStdClasses.sSortable,n.oJUIClasses.sSortableAsc,n.oJUIClasses.sSortableDesc,n.oJUIClasses.sSortableNone].join(" "));j("th span",a.nTHead).remove()}else j("th",a.nTHead).removeClass([n.oStdClasses.sSortable,n.oStdClasses.sSortableAsc,n.oStdClasses.sSortableDesc,n.oStdClasses.sSortableNone].join(" "));b.appendChild(a.nTable);d=0;for(f=a.aoData.length;d<
f;d++)c.appendChild(a.aoData[d].nTr);a.nTable.style.width=v(a.sDestroyWidth);j(">tr:even",c).addClass(a.asDestoryStrips[0]);j(">tr:odd",c).addClass(a.asDestoryStrips[1]);d=0;for(f=D.length;d<f;d++)D[d]==a&&D.splice(d,1)};this.fnAdjustColumnSizing=function(a){var b=A(this[n.iApiIndex]);X(b);if(typeof a=="undefined"||a)this.fnDraw(false);else if(b.oScroll.sX!==""||b.oScroll.sY!=="")this.oApi._fnScrollDraw(b)};for(var pa in n.oApi)if(pa)this[pa]=r(pa);this.oApi._fnExternApiFunc=r;this.oApi._fnInitalise=
s;this.oApi._fnLanguageProcess=y;this.oApi._fnAddColumn=F;this.oApi._fnColumnOptions=x;this.oApi._fnAddData=u;this.oApi._fnGatherData=z;this.oApi._fnDrawHead=U;this.oApi._fnDraw=C;this.oApi._fnReDraw=W;this.oApi._fnAjaxUpdate=ta;this.oApi._fnAjaxUpdateDraw=ua;this.oApi._fnAddOptionsHtml=sa;this.oApi._fnFeatureHtmlTable=za;this.oApi._fnScrollDraw=Ca;this.oApi._fnAjustColumnSizing=X;this.oApi._fnFeatureHtmlFilter=xa;this.oApi._fnFilterComplete=P;this.oApi._fnFilterCustom=Fa;this.oApi._fnFilterColumn=
Ea;this.oApi._fnFilter=Da;this.oApi._fnBuildSearchArray=ha;this.oApi._fnBuildSearchRow=ka;this.oApi._fnFilterCreateSearch=ia;this.oApi._fnDataToSearch=ja;this.oApi._fnSort=O;this.oApi._fnSortAttachListener=ba;this.oApi._fnSortingClasses=T;this.oApi._fnFeatureHtmlPaginate=Ba;this.oApi._fnPageChange=ea;this.oApi._fnFeatureHtmlInfo=Aa;this.oApi._fnUpdateInfo=Ga;this.oApi._fnFeatureHtmlLength=wa;this.oApi._fnFeatureHtmlProcessing=ya;this.oApi._fnProcessingDisplay=K;this.oApi._fnVisibleToColumnIndex=ga;
this.oApi._fnColumnIndexToVisible=M;this.oApi._fnNodeToDataIndex=Q;this.oApi._fnVisbleColumns=S;this.oApi._fnCalculateEnd=E;this.oApi._fnConvertToWidth=Ha;this.oApi._fnCalculateColumnWidths=$;this.oApi._fnScrollingWidthAdjust=Ja;this.oApi._fnGetWidestNode=Ia;this.oApi._fnGetMaxLenString=Ka;this.oApi._fnStringToCss=v;this.oApi._fnArrayCmp=Oa;this.oApi._fnDetectType=aa;this.oApi._fnSettingsFromNode=A;this.oApi._fnGetDataMaster=V;this.oApi._fnGetTrNodes=R;this.oApi._fnGetTdNodes=Z;this.oApi._fnEscapeRegex=
la;this.oApi._fnDeleteIndex=ma;this.oApi._fnReOrderIndex=va;this.oApi._fnColumnOrdering=ca;this.oApi._fnLog=H;this.oApi._fnClearTable=da;this.oApi._fnSaveState=na;this.oApi._fnLoadState=Ma;this.oApi._fnCreateCookie=La;this.oApi._fnReadCookie=oa;this.oApi._fnGetUniqueThs=fa;this.oApi._fnScrollBarWidth=Na;this.oApi._fnApplyToChildren=L;this.oApi._fnMap=o;var qa=this;return this.each(function(){var a=0,b,c,d,f;a=0;for(b=D.length;a<b;a++){if(D[a].nTable==this)if(typeof g=="undefined"||typeof g.bRetrieve!=
"undefined"&&g.bRetrieve===true)return D[a].oInstance;else if(typeof g.bDestroy!="undefined"&&g.bDestroy===true){D[a].oInstance.fnDestroy();break}else{H(D[a],0,"Cannot reinitialise DataTable.\n\nTo retrieve the DataTables object for this table, please pass either no arguments to the dataTable() function, or set bRetrieve to true. Alternatively, to destory the old table and create a new one, set bDestroy to true (note that a lot of changes to the configuration can be made through the API which is usually much faster).");
return}if(D[a].sTableId!==""&&D[a].sTableId==this.getAttribute("id")){D.splice(a,1);break}}var e=new m;D.push(e);var i=false,h=false;a=this.getAttribute("id");if(a!==null){e.sTableId=a;e.sInstance=a}else e.sInstance=n._oExternConfig.iNextUnique++;if(this.nodeName.toLowerCase()!="table")H(e,0,"Attempted to initialise DataTables on a node which is not a table: "+this.nodeName);else{e.nTable=this;e.oInstance=qa.length==1?qa:j(this).dataTable();e.oApi=qa.oApi;e.sDestroyWidth=j(this).width();if(typeof g!=
"undefined"&&g!==null){e.oInit=g;o(e.oFeatures,g,"bPaginate");o(e.oFeatures,g,"bLengthChange");o(e.oFeatures,g,"bFilter");o(e.oFeatures,g,"bSort");o(e.oFeatures,g,"bInfo");o(e.oFeatures,g,"bProcessing");o(e.oFeatures,g,"bAutoWidth");o(e.oFeatures,g,"bSortClasses");o(e.oFeatures,g,"bServerSide");o(e.oScroll,g,"sScrollX","sX");o(e.oScroll,g,"sScrollXInner","sXInner");o(e.oScroll,g,"sScrollY","sY");o(e.oScroll,g,"bScrollCollapse","bCollapse");o(e.oScroll,g,"bScrollInfinite","bInfinite");o(e.oScroll,
g,"iScrollLoadGap","iLoadGap");o(e.oScroll,g,"bScrollAutoCss","bAutoCss");o(e,g,"asStripClasses");o(e,g,"fnRowCallback");o(e,g,"fnHeaderCallback");o(e,g,"fnFooterCallback");o(e,g,"fnCookieCallback");o(e,g,"fnInitComplete");o(e,g,"fnServerData");o(e,g,"fnFormatNumber");o(e,g,"aaSorting");o(e,g,"aaSortingFixed");o(e,g,"aLengthMenu");o(e,g,"sPaginationType");o(e,g,"sAjaxSource");o(e,g,"iCookieDuration");o(e,g,"sCookiePrefix");o(e,g,"sDom");o(e,g,"oSearch","oPreviousSearch");o(e,g,"aoSearchCols","aoPreSearchCols");
o(e,g,"iDisplayLength","_iDisplayLength");o(e,g,"bJQueryUI","bJUI");o(e.oLanguage,g,"fnInfoCallback");typeof g.fnDrawCallback=="function"&&e.aoDrawCallback.push({fn:g.fnDrawCallback,sName:"user"});typeof g.fnStateSaveCallback=="function"&&e.aoStateSave.push({fn:g.fnStateSaveCallback,sName:"user"});typeof g.fnStateLoadCallback=="function"&&e.aoStateLoad.push({fn:g.fnStateLoadCallback,sName:"user"});e.oFeatures.bServerSide&&e.oFeatures.bSort&&e.oFeatures.bSortClasses&&e.aoDrawCallback.push({fn:T,sName:"server_side_sort_classes"});
if(typeof g.bJQueryUI!="undefined"&&g.bJQueryUI){e.oClasses=n.oJUIClasses;if(typeof g.sDom=="undefined")e.sDom='<"H"lfr>t<"F"ip>'}if(e.oScroll.sX!==""||e.oScroll.sY!=="")e.oScroll.iBarWidth=Na();if(typeof g.iDisplayStart!="undefined"&&typeof e.iInitDisplayStart=="undefined"){e.iInitDisplayStart=g.iDisplayStart;e._iDisplayStart=g.iDisplayStart}if(typeof g.bStateSave!="undefined"){e.oFeatures.bStateSave=g.bStateSave;Ma(e,g);e.aoDrawCallback.push({fn:na,sName:"state_save"})}if(typeof g.aaData!="undefined")h=
true;if(typeof g!="undefined"&&typeof g.aoData!="undefined")g.aoColumns=g.aoData;if(typeof g.oLanguage!="undefined")if(typeof g.oLanguage.sUrl!="undefined"&&g.oLanguage.sUrl!==""){e.oLanguage.sUrl=g.oLanguage.sUrl;j.getJSON(e.oLanguage.sUrl,null,function(q){y(e,q,true)});i=true}else y(e,g.oLanguage,false)}else g={};if(typeof g.asStripClasses=="undefined"){e.asStripClasses.push(e.oClasses.sStripOdd);e.asStripClasses.push(e.oClasses.sStripEven)}c=false;d=j(">tbody>tr",this);a=0;for(b=e.asStripClasses.length;a<
b;a++)if(d.filter(":lt(2)").hasClass(e.asStripClasses[a])){c=true;break}if(c){e.asDestoryStrips=["",""];if(j(d[0]).hasClass(e.oClasses.sStripOdd))e.asDestoryStrips[0]+=e.oClasses.sStripOdd+" ";if(j(d[0]).hasClass(e.oClasses.sStripEven))e.asDestoryStrips[0]+=e.oClasses.sStripEven;if(j(d[1]).hasClass(e.oClasses.sStripOdd))e.asDestoryStrips[1]+=e.oClasses.sStripOdd+" ";if(j(d[1]).hasClass(e.oClasses.sStripEven))e.asDestoryStrips[1]+=e.oClasses.sStripEven;d.removeClass(e.asStripClasses.join(" "))}a=this.getElementsByTagName("thead");
c=a.length===0?[]:fa(a[0]);var k;if(typeof g.aoColumns=="undefined"){k=[];a=0;for(b=c.length;a<b;a++)k.push(null)}else k=g.aoColumns;a=0;for(b=k.length;a<b;a++){if(typeof g.saved_aoColumns!="undefined"&&g.saved_aoColumns.length==b){if(k[a]===null)k[a]={};k[a].bVisible=g.saved_aoColumns[a].bVisible}F(e,c?c[a]:null)}if(typeof g.aoColumnDefs!="undefined")for(a=g.aoColumnDefs.length-1;a>=0;a--){var l=g.aoColumnDefs[a].aTargets;j.isArray(l)||H(e,1,"aTargets must be an array of targets, not a "+typeof l);
c=0;for(d=l.length;c<d;c++)if(typeof l[c]=="number"&&l[c]>=0){for(;e.aoColumns.length<=l[c];)F(e);x(e,l[c],g.aoColumnDefs[a])}else if(typeof l[c]=="number"&&l[c]<0)x(e,e.aoColumns.length+l[c],g.aoColumnDefs[a]);else if(typeof l[c]=="string"){b=0;for(f=e.aoColumns.length;b<f;b++)if(l[c]=="_all"||e.aoColumns[b].nTh.className.indexOf(l[c])!=-1)x(e,b,g.aoColumnDefs[a])}}if(typeof k!="undefined"){a=0;for(b=k.length;a<b;a++)x(e,a,k[a])}a=0;for(b=e.aaSorting.length;a<b;a++){if(e.aaSorting[a][0]>=e.aoColumns.length)e.aaSorting[a][0]=
0;k=e.aoColumns[e.aaSorting[a][0]];if(typeof e.aaSorting[a][2]=="undefined")e.aaSorting[a][2]=0;if(typeof g.aaSorting=="undefined"&&typeof e.saved_aaSorting=="undefined")e.aaSorting[a][1]=k.asSorting[0];c=0;for(d=k.asSorting.length;c<d;c++)if(e.aaSorting[a][1]==k.asSorting[c]){e.aaSorting[a][2]=c;break}}T(e);this.getElementsByTagName("thead").length===0&&this.appendChild(p.createElement("thead"));this.getElementsByTagName("tbody").length===0&&this.appendChild(p.createElement("tbody"));e.nTHead=this.getElementsByTagName("thead")[0];
e.nTBody=this.getElementsByTagName("tbody")[0];if(this.getElementsByTagName("tfoot").length>0)e.nTFoot=this.getElementsByTagName("tfoot")[0];if(h)for(a=0;a<g.aaData.length;a++)u(e,g.aaData[a]);else z(e);e.aiDisplay=e.aiDisplayMaster.slice();e.bInitialised=true;i===false&&s(e)}})}})(jQuery,window,document);
/**
 * Copyright (c) 2008 Google Inc.
 *
 * You are free to copy and use this sample.
 * License can be found here: http://code.google.com/apis/ajaxsearch/faq/#license
*/

/**
 * @fileoverview A feed gadget based on the AJAX Feed API.
 * @author dcollison@google.com (Derek Collison)
 */

/**
 * GFdynamicFeedControl
 * @param {String} feed The feed URL.
 * @param {String|Object} container Either the id string or the element itself.
 * @param {Object} options Options map.
 * @constructor
 */

function GFdynamicFeedControl(feedUrls, container, options) {
  // node elements.
  this.nodes = {};
  this.collapseElements = [];
  
  // the feeds.
  this.feeds = [];
  this.results = [];

  if (typeof feedUrls == 'string') {
    this.feeds.push({url:feedUrls});
  } else if (typeof feedUrls == 'object') {
    for (var i=0; i<feedUrls.length; i++) {
      var entry = feedUrls[i];
      var o = {};
      var feedUrl;
      if (typeof entry == 'string') {
        o.url = feedUrls[i];
      } else if (typeof entry == 'object') {
        o = feedUrls[i];
	if (o && o.title) {
	  var s = o.title;
	  o.title = s.replace(/</g,'&lt;').replace(/>/g, '&gt;');
	}
      }
      this.feeds.push(o);
    }
  }

  if (typeof container == "string") {
    container = document.getElementById(container);
  }
  this.parseOptions_(options);
  this.setup_(container);
}

/*
 * Default time in milliseconds for the feed to be reloaded.
 * @type Number
 */
GFdynamicFeedControl.DEFAULT_NUM_RESULTS = 4;
/*
 * Default time in milliseconds for the feed to be reloaded.
 * @type Number
 */
GFdynamicFeedControl.DEFAULT_FEED_CYCLE_TIME = 1800000;
/*
 * Default display time in milliseconds for each entry.
 * @type Number
 */
GFdynamicFeedControl.DEFAULT_DISPLAY_TIME = 5000;
/*
 * Default fadeout transition time in milliseconds for each entry.
 * @type Number
 */
GFdynamicFeedControl.DEFAULT_FADEOUT_TIME = 1000;
/*
 * Default time between transition steps in milliseconds
 * @type Number
 */
GFdynamicFeedControl.DEFAULT_TRANSISTION_STEP = 40;
/*
 * Default hover time in milliseconds for each entry.
 * @type Number
 */
GFdynamicFeedControl.DEFAULT_HOVER_TIME = 100;

/**
 * Setup default option map and apply overrides from constructor.
 * @param {Object} options Options map.
 * @private
 */
GFdynamicFeedControl.prototype.parseOptions_ = function(options) {
  // Default Options
  // TODO(dcollison) - implement Feed Cycle.
  this.options = {
    numResults : GFdynamicFeedControl.DEFAULT_NUM_RESULTS,
    feedCycleTime : GFdynamicFeedControl.DEFAULT_FEED_CYCLE_TIME,
    linkTarget : google.feeds.LINK_TARGET_BLANK,
    displayTime : GFdynamicFeedControl.DEFAULT_DISPLAY_TIME,
    transitionTime : GFdynamicFeedControl.DEFAULT_TRANSISTION_TIME,
    transitionStep : GFdynamicFeedControl.DEFAULT_TRANSISTION_STEP,
    fadeOutTime: GFdynamicFeedControl.DEFAULT_FADEOUT_TIME,
    scrollOnFadeOut : true,
    pauseOnHover : true,
    hoverTime : GFdynamicFeedControl.DEFAULT_HOVER_TIME,
    autoCleanup : true,
    transitionCallback : null,
    feedTransitionCallback : null,
    feedLoadCallback : null,
    collapseable : false,
    sortByDate : false,
    horizontal : false,
    stacked : false,
    title : null
  };

  if (options) {
    for (var o in this.options) {
      if (typeof options[o] != 'undefined') {
        this.options[o] = options[o];
      }
    }
  }
  
  // Cant be collapseable unless stacked
  if(!this.options.stacked) {
    this.options.collapseable = false;
  }
  
  // Override strange/bad options
  this.options.displayTime = Math.max(200, this.options.displayTime);
  this.options.fadeOutTime = Math.max(0, this.options.fadeOutTime);

  // Calculated
  var ts = this.options.fadeOutTime / this.options.transitionStep;
  this.fadeOutDelta = Math.min(1, (1.0/ts));

  // Flag to start
  this.started = false;
};

/**
 * Basic setup.
 * @private
 */
GFdynamicFeedControl.prototype.setup_ = function(container) {
  if (container == null) return;
  this.nodes.container = container;

  // Browser fun.
  if (window.ActiveXObject) {
    this.ie = this[window.XMLHttpRequest ? 'ie7' : 'ie6'] = true;
  } else if (document.childNodes && !document.all && !navigator.taintEnabled) {
    this.safari = true;
  } else if (document.getBoxObjectFor != null) {
    this.gecko = true;
  }
  // The feedControl instance for generating entry HTML.
  this.feedControl = new google.feeds.FeedControl();
  this.feedControl.setLinkTarget(this.options.linkTarget);

  // The feeds
  this.expected = this.feeds.length;
  this.errors = 0;

  for (var i = 0; i < this.feeds.length; i++) {
    var feed = new google.feeds.Feed(this.feeds[i].url);
    feed.setResultFormat(google.feeds.Feed.JSON_FORMAT);
    feed.setNumEntries(this.options.numResults);
    feed.load(this.bind_(this.feedLoaded_, i));
  }
};

/**
 * Helper method to bind this instance correctly.
 * @param {Object} method function/method to bind.
 * @return {Function}
 * @private
 */
GFdynamicFeedControl.prototype.bind_ = function(method) {
  var self = this;
  var opt_args = [].slice.call(arguments, 1);
  return function() {
    var args = opt_args.concat([].slice.call(arguments));
    return method.apply(self, args);
  }
};

/**
 * Callback associated with the AJAX Feed api after load.
 * @param {Object} result Loaded result.
 * @private
 */
GFdynamicFeedControl.prototype.feedLoaded_ = function(index, result) {
  if (this.options.feedLoadCallback) {
    this.options.feedLoadCallback(result);
  }
  if (result.error) {
    // Ignore failed feeds for the most part.
    // The user has control through the feedLoadCallback above
    // if they choose to do something more createive.
    // Only complain if we can't load anything.
    if (++this.errors >= this.expected) {
      this.nodes.container.innerHTML = 'Feed' + ((this.expected > 1)?'s ':' ') +
                                       'could not be loaded.';
    }
    return;
  }
  // Override of title option.
  if (this.feeds[index].title) {
    result.feed.title = this.feeds[index].title;
  }
  this.results.push(result);

  if (!this.started) {
    this.createSubContainers_();
    this.displayResult_(0);
  } else if (!this.options.horizontal && this.options.stacked) {
    this.addResult_(this.results.length-1);
  }
};

/**
 * Insert blog in correct place
 * @private
 */
GFdynamicFeedControl.prototype.sortByDate_ = function(resultIndex, newTitle,
                                                      newList) {
  // if sorting by date, insert it into the correct spot
  var newEntryDate = this.results[resultIndex].feed.entries[0].publishedDate;
  var newEntryDateMS = Date.parse(newEntryDate);
  var insertIndex = null;

  for (var i = 0; i < this.results.length; i++) {
    var mostRecentPost = this.results[i].feed.entries[0].publishedDate;
    var mostRecentPostMS = Date.parse(mostRecentPost);
    if(newEntryDateMS > mostRecentPostMS) {
      insertIndex = i;
      break;
    }
  }

  // If it's most stale blog, just append as usual
  if(insertIndex == null) {
    this.nodes.root.appendChild(newTitle);
    this.nodes.root.appendChild(newList);
    this.createListEntries_(resultIndex, newList);
    return;
  }

  // If it is fresher than a blog, insert to correct position
  var insertBeforeIndex = 2 + (insertIndex * 2);
  var swapToIndex = insertBeforeIndex + 2;
  var tempSwap = null;
  var myResultIndex = resultIndex + 1;

  var sectionsToChange = this.nodes.root.childNodes;
  var nodeToInsertBefore = sectionsToChange[insertBeforeIndex];

  this.nodes.root.insertBefore(newTitle, nodeToInsertBefore);
  this.nodes.root.insertBefore(newList, nodeToInsertBefore);

  this.results.splice(insertIndex, 0, this.results[resultIndex]);
  this.results.splice(myResultIndex, 1);
  
  var nodesToChangeClick = sectionsToChange[swapToIndex].nextSibling.childNodes;
  
  this.createListEntries_(insertIndex, newList);

  // Keep freshest blog open first
  if(insertIndex == 0) {
    this.displayResult_(0);
  }

  insertIndex += 1;
  // Reset all of the onmousehover listeners to highlight corect index
  for (var i = swapToIndex; i < sectionsToChange.length; i += 2) {
    var nodesToChangeClick = sectionsToChange[i].nextSibling.childNodes;
    for (var j=0; j < nodesToChangeClick.length; j++) {
      nodesToChangeClick[j].onmouseover = this.bind_(this.listMouseOver_, 
                                                     insertIndex, j);
      nodesToChangeClick[j].onmouseout = this.bind_(this.listMouseOut_, 
                                                    insertIndex, j);
    }
    insertIndex++;
  }
};

/**
 * Setup to display the Result for stacked mode
 * @private
 */
GFdynamicFeedControl.prototype.addResult_ = function(resultIndex) {
  var result = this.results[resultIndex];
  var newTitle = this.createDiv_('gfg-subtitle');
  this.setTitle_(result.feed, newTitle);
  var newList = this.createDiv_('gfg-list');

  // add a collapseable button
  if(this.options.collapseable) {
    var collapseLink = document.createElement('div');
    newList.style.display = 'none';
    collapseLink.className = 'gfg-collapse-closed';
    newTitle.appendChild(collapseLink);
    collapseLink.onclick = this.toggleCollapse(this, newList, collapseLink);
    this.collapseElements.push({
      list : newList,
      collapse : collapseLink
    });
  }


  var clearFloat = document.createElement('div');
  clearFloat.className = 'clearFloat';
  newTitle.appendChild(clearFloat);

  // If not sorting by date, add them as usual
  if(!this.options.sortByDate) {
    this.nodes.root.appendChild(newTitle);
    this.nodes.root.appendChild(newList);
    this.createListEntries_(resultIndex, newList);
  } else {
    this.sortByDate_(resultIndex, newTitle, newList);
  }
  
};

/**
 * Setup to display the Result
 * @private
 */
GFdynamicFeedControl.prototype.displayResult_ = function(resultIndex) {
  this.resultIndex = resultIndex;
  var result = this.results[resultIndex];
  if (this.options.feedTransitionCallback) {
    this.options.feedTransitionCallback(result);
  }
  if (this.options.title) {
    this.setPlainTitle_(this.options.title);
  } else {
    this.setTitle_(result.feed);
  }
  this.clearNode_(this.nodes.entry);

  if (this.started && !this.options.horizontal && this.options.stacked) {
    this.entries = result.feed.entries;
  } else {
    this.createListEntries_(resultIndex, this.nodes.list);
  }
  this.displayEntries_();
}

/**
 * Set the Title to just plaintext
 * @private
 */
GFdynamicFeedControl.prototype.setPlainTitle_ = function(title, opt_element) {
  var el = opt_element || this.nodes.title;
  el.innerHTML = title;
}

/**
 * Set the Title
 * @private
 */
GFdynamicFeedControl.prototype.setTitle_ = function(resultFeed, opt_element) {
  var el = opt_element || this.nodes.title;
  this.clearNode_(el);
  var link = document.createElement('a');
  link.target = google.feeds.LINK_TARGET_BLANK;
  link.href = resultFeed.link;
  link.className = 'gfg-collapse-href';
  link.innerHTML = resultFeed.title;
  el.appendChild(link);
}

GFdynamicFeedControl.prototype.toggleCollapse = function(feedControl, 
                                                         listReference, 
                                                         collapseLink) {
  return function() {
    var els = feedControl.collapseElements;
    for (var i=0; i < els.length; i++) {
      var el = els[i];
      el.list.style.display = 'none';
      el.collapse.className = 'gfg-collapse-closed';
    }
    listReference.style.display = 'block';
    collapseLink.className = 'gfg-collapse-open';
  }
}

/**
 * Create the list Entries
 * @private
 */
GFdynamicFeedControl.prototype.createListEntries_ = function(resultIndex, node) {
  var entries = this.results[resultIndex].feed.entries;
  this.clearNode_(node);
  for (var i = 0; i < entries.length; i++) {
    this.feedControl.createHtml(entries[i]);
    var className = 'gfg-listentry ';
    className += (i%2)?'gfg-listentry-even':'gfg-listentry-odd';
    var listEntry = this.createDiv_(className);
    var link = this.createLink_(entries[i].link,
                                entries[i].title,
                                this.options.linkTarget);
    listEntry.appendChild(link);
    if (this.options.pauseOnHover) {
      listEntry.onmouseover = this.bind_(this.listMouseOver_, resultIndex, i);
      listEntry.onmouseout = this.bind_(this.listMouseOut_, resultIndex, i);
    }
    entries[i].listEntry = listEntry;
    node.appendChild(listEntry);
  }
  if (node == this.nodes.list) {
    this.entries = entries;
  }
}

/**
 * Begin to display the entries.
 * @private
 */
GFdynamicFeedControl.prototype.displayEntries_ = function() {
  this.entryIndex = 0;
  this.displayCurrentEntry_();
  this.setDisplayTimer_();
  this.started = true;
}

/**
 * Display next entry.
 * @private
 */
GFdynamicFeedControl.prototype.displayNextEntry_ = function() {
  // Check to see if we have been orphaned and need to cleanup..
  if (this.options.autoCleanup && this.isOrphaned_()) {
      this.cleanup_();
      return;
  }

  if (++this.entryIndex >= this.entries.length) {
    // End of list, see if we should rotate feeds..
    if (this.results.length > 1) {
      if (++this.resultIndex >= this.results.length) {
        this.resultIndex = 0;
      }
      this.displayResult_(this.resultIndex);
      return;
    } else {
      this.entryIndex = 0;
    }
  }

  if (this.options.transitionCallback) {
    this.options.transitionCallback(this.entries[this.entryIndex]);
  }
  this.displayCurrentEntry_();
  this.setDisplayTimer_();
}

/**
 * Display current entry.
 * @private
 */
GFdynamicFeedControl.prototype.displayCurrentEntry_ = function() {
  this.clearNode_(this.nodes.entry);
  this.current = this.entries[this.entryIndex].html;
  this.current.style.top = '0px';
  this.nodes.entry.appendChild(this.current);
  this.createOverlay_();
  
  // Expand the blog who's post is being displayed
  if(this.options.collapseable) {
    var feedTitle = null;
    
    for (var i=0; i < this.results.length; i++) {
      if(this.results[i].feed.entries == this.entries) {
        feedTitle = this.results[i].feed.title;
      }
    }

    var els = this.collapseElements;

    for (var i=0; i < els.length; i++) {
      var el = els[i];
      var divfeedTitle = el.collapse.previousSibling.innerHTML;
      var expandClicker = el.collapse;
      if(feedTitle == divfeedTitle) {
        if(this.ie) {
          expandClicker.click();
        } else {
          expandClicker.onclick();
        }

      }
    }
  }
  
  if (this.currentList) {
    var className = 'gfg-listentry ';
    className += (this.currentListIndex%2)?
        'gfg-listentry-even':'gfg-listentry-odd';
    this.currentList.className = className;
  }
  this.currentList = this.entries[this.entryIndex].listEntry;
  this.currentListIndex = this.entryIndex;
  var className = 'gfg-listentry gfg-listentry-highlight ';
  className += (this.currentListIndex%2)?
       'gfg-listentry-even':'gfg-listentry-odd';
  this.currentList.className = className;
}

/**
 * Simulated mouse hover events for list entries.
 * @private
 */
GFdynamicFeedControl.prototype.listMouseHover_ = function(resultIndex,
                                                          listIndex) {
  var result = this.results[resultIndex];
  var listEntry = result.feed.entries[listIndex].listEntry;
  listEntry.selectTimer = null;
  this.clearTransitionTimer_();
  this.clearDisplayTimer_();
  this.resultIndex = resultIndex;
  this.entries = result.feed.entries;
  this.entryIndex = listIndex;
  this.displayCurrentEntry_();
}

/**
 * Mouse over events for list entries.
 * @private
 */
GFdynamicFeedControl.prototype.listMouseOver_ = function(resultIndex,
                                                         listIndex) {
  var result = this.results[resultIndex];
  var listEntry = result.feed.entries[listIndex].listEntry;
  var cb = this.bind_(this.listMouseHover_, resultIndex, listIndex);
  listEntry.selectTimer = setTimeout(cb, this.options.hoverTime);
}

/**
 * Mouse out events for list entries.
 * @private
 */
GFdynamicFeedControl.prototype.listMouseOut_ = function(resultIndex, listIndex) {
  var result = this.results[resultIndex];
  var listEntry = result.feed.entries[listIndex].listEntry;
  if (listEntry.selectTimer) {
    clearTimeout(listEntry.selectTimer);
    listEntry.selectTimer = null;
  } else {
    this.setDisplayTimer_();
  }
}

/**
 * Mouse over events for main entry.
 * @private
 */
GFdynamicFeedControl.prototype.entryMouseOver_ = function(e) {
  this.clearDisplayTimer_();
  if (this.transitionTimer) {
    this.clearTransitionTimer_();
    this.displayCurrentEntry_();
  }
}

/**
 * Mouse out events for main entry.
 * @private
 */
GFdynamicFeedControl.prototype.entryMouseOut_ = function(e) {
  this.setDisplayTimer_();
}

/**
 * Create the overlay div. This hack is for IE and transparency effects.
 * @private
 */
GFdynamicFeedControl.prototype.createOverlay_ = function() {
  if (this.current == null) return;
  // Create div lazily and hold on to it..
  if (this.overlay == null) {
    var overlay = this.createDiv_('gfg-entry');
    overlay.style.position = 'absolute';
    overlay.style.top = '0px';
    overlay.style.left = '0px';
    this.overlay = overlay;
  }
  this.setOpacity_(this.overlay, 0);
  this.nodes.entry.appendChild(this.overlay);
}

/**
 * Sets the display timer.
 * @private
 */
GFdynamicFeedControl.prototype.setDisplayTimer_ = function() {
  if (this.displayTimer) {
    this.clearDisplayTimer_();
  }
  var cb = this.bind_(this.setFadeOutTimer_);
  this.displayTimer = setTimeout(cb, this.options.displayTime);
};

/**
 * Class helper method for the time now in milliseconds
 * @private
 */
GFdynamicFeedControl.timeNow = function() {
  var d = new Date();
  return d.getTime();
};

/**
 * Transition animation for fadeout. Cleanup when finished.
 * @private
 */
GFdynamicFeedControl.prototype.fadeOutEntry_ = function() {
  if (this.overlay) {
    var delta = this.fadeOutDelta;
    var ts = this.options.transitionStep;
    var now = GFdynamicFeedControl.timeNow();
    var tick = now - this.lastTick;
    this.lastTick = now;
    delta *= (tick/ts);

    var op = this.overlay.opacity + delta;
    // Overlay opacity
    this.setOpacity_(this.overlay, op);
    // Scroll down
    if (this.options.scrollOnFadeOut && (op > .5)) {
      var r = (op-.5)*2;
      var newTop = Math.round(this.current.offsetHeight * r);
      this.current.style.top = newTop + 'px';
    }
    if (op < 1) return;
  }
  // Finished.
  this.clearTransitionTimer_();
  this.displayNextEntry_();
};

/**
 * Sets the transition timer for fadeout.
 * @private
 */
GFdynamicFeedControl.prototype.setFadeOutTimer_ = function() {
  this.clearTransitionTimer_();
  this.lastTick = GFdynamicFeedControl.timeNow();
  var cb = this.bind_(this.fadeOutEntry_);
  this.transitionTimer = setInterval(cb, this.options.transitionStep);
};

/**
 * Clear the transition timer. Used to prevent leaks.
 * @private
 */
GFdynamicFeedControl.prototype.clearTransitionTimer_ = function() {
  if (this.transitionTimer) {
    clearInterval(this.transitionTimer);
    this.transitionTimer = null;
  }
};

/**
 * Clear the display timer.
 * @private
 */
GFdynamicFeedControl.prototype.clearDisplayTimer_ = function() {
  if (this.displayTimer) {
    clearTimeout(this.displayTimer);
    this.displayTimer = null;
  }
};

/**
 * Setup our own subcontainer to the user supplied container.
 * @private
 */
GFdynamicFeedControl.prototype.createSubContainers_ = function() {
  var nodes = this.nodes;
  var container = this.nodes.container;

  this.clearNode_(container);
  if (this.options.horizontal) {
    container = this.createDiv_('gfg-horizontal-container');
    nodes.root = this.createDiv_('gfg-horizontal-root');
    this.nodes.container.appendChild(container);
  } else {
    nodes.root = this.createDiv_('gfg-root');
  }
  nodes.title = this.createDiv_('gfg-title');
  nodes.entry = this.createDiv_('gfg-entry');
  nodes.list = this.createDiv_('gfg-list');
  nodes.root.appendChild(nodes.title);
  nodes.root.appendChild(nodes.entry);

  if (!this.options.horizontal && this.options.stacked) {
    var newTitle = this.createDiv_('gfg-subtitle');
    nodes.root.appendChild(newTitle);
    this.setTitle_(this.results[0].feed, newTitle);
    
    if(this.options.collapseable) {
      var collapseLink = document.createElement('div');
      collapseLink.className = 'gfg-collapse-open';
      newTitle.appendChild(collapseLink);
      collapseLink.onclick = this.toggleCollapse(this, nodes.list, collapseLink);
      this.collapseElements.push({
        list : nodes.list,
        collapse : collapseLink
      });
      nodes.list.style.display = 'block';
    }
    
    var clearFloat = document.createElement('div');
    clearFloat.className = 'clearFloat';
    newTitle.appendChild(clearFloat);
  }
  
  nodes.root.appendChild(nodes.list);
  container.appendChild(nodes.root);

  if (this.options.pauseOnHover) {
    nodes.entry.onmouseover = this.bind_(this.entryMouseOver_);
    nodes.entry.onmouseout = this.bind_(this.entryMouseOut_);
  }

  // Add Branding.
  if (this.options.horizontal) {
    nodes.branding = this.createDiv_('gfg-branding');
    google.feeds.getBranding(nodes.branding, google.feeds.VERTICAL_BRANDING);
    container.appendChild(nodes.branding);
  }
};

/**
 * Helper method to properly clear a node and its children.
 * @param {Object} node Node to clear.
 * @private
 */
GFdynamicFeedControl.prototype.clearNode_ = function(node) {
  if (node == null) return;
  var child;
  while ((child = node.firstChild)) {
    node.removeChild(child);
  }
};

/**
 * Helper method to create a div with optional class and text.
 * @param {String} opt_className Optional className for the div.
 * @param {String} opt_text Optional text for the innerHTML.
 * @private
 */
GFdynamicFeedControl.prototype.createDiv_ = function(opt_className, opt_text) {
  var el = document.createElement("div");
  if (opt_text) {
    el.innerHTML = opt_text;
  }
  if (opt_className) { el.className = opt_className; }
  return el;
};

/**
 * Helper method to create a link with href and text.
 * @param {String} href Href URL
 * @param {String} text text for the link.
 * @param {String} opt_target Optional link target.
 * @private
 */
GFdynamicFeedControl.prototype.createLink_ = function(href, text, opt_target) {
  var link = document.createElement('a');
  link.href = href;
  link.innerHTML = text;
  if (opt_target) {
    link.target = opt_target;
  }
  return link;
};

/**
 * Cleanup results on being orphaned.
 * @private
 */
GFdynamicFeedControl.prototype.clearResults_ = function() {
  for (var i=0; i < this.results.length; i++) {
    var result = this.results[i];
    var entries = result.feed.entries;
    for (var i = 0; i < entries.length; i++) {
      var entry = entries[i];
      entry.html = null;
      entry.listEntry.onmouseover = null;
      entry.listEntry.onmouseout = null;
      if (entry.listEntry.selectTimer) {
        clearTimeout(entry.listEntry.selectTimer);
        entry.listEntry.selectTimer = null;
      }
      entry.listEntry = null;
    }
  }
}

/**
 * Check for being orphaned.
 * @private
 */
GFdynamicFeedControl.prototype.isOrphaned_ = function() {
  var root = this.nodes.root;
  var orphaned = false;
  if (!root || !root.parentNode) {
    orphaned = true;
  } else if (this.options.horizontal && !root.parentNode.parentNode) {
    orphaned = true;
  }
  return orphaned;
}

/**
 * Cleanup on being orphaned.
 * @private
 */
GFdynamicFeedControl.prototype.cleanup_ = function() {
  this.started = false;
  // Timer Events.
  this.clearDisplayTimer_();
  this.clearTransitionTimer_();
  // Structures
  this.clearResults_();
  // Nodes
  this.clearNode_(this.nodes.root);
  this.nodes.container = null;
}

/**
 * Helper method to set opacity for nodes.. Also takes into account
 * visibility in general.
 * @param {Element} node element.
 * @param {Number} opacity alpha level.
 * @private
 */
GFdynamicFeedControl.prototype.setOpacity_ = function(node, opacity) {
  if (node == null) return;
  opacity = Math.max(0, Math.min(1, opacity));
  if (opacity == 0) {
    if (node.style.visibility != 'hidden') {
      node.style.visibility = 'hidden';
    }
  } else {
    if (node.style.visibility != 'visible') {
      node.style.visibility = 'visible';
    }
  }
  if (this.ie) {
    var normalized = Math.round(opacity*100);
    node.style.filter = 'alpha(opacity=' + normalized + ')';
  }
  node.style.opacity = node.opacity = opacity;
};

GFgadget = GFdynamicFeedControl;



