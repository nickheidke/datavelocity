/*global my */

my.Common.Utilities = (function ($) {
    "use strict";

    function commafy(num) {
        var str = num.toString().split('.');
        if (str[0].length >= 4) {
            str[0] = str[0].replace(/(\d)(?=(\d{3})+$)/g, '$1,');
        }
        if (str[1] && str[1].length >= 4) {
            str[1] = str[1].replace(/(\d{3})/g, '$1 ');
        }
        return str.join('.');
    }

    return {
        commafy: commafy
    };

})(this.jQuery);