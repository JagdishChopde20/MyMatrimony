

(function ($, document, window, viewport) {
    var visibilityDivs = {
        'xs': $('<div class="d-xs-block d-sm-none d-md-none d-lg-none d-xl-none"></div>'),
        'sm': $('<div class="d-none d-sm-block d-md-none d-lg-none d-xl-none"></div>'),
        'md': $('<div class="d-none d-md-block d-sm-none d-lg-none d-xl-none"></div>'),
        'lg': $('<div class="d-none d-lg-block d-sm-none d-md-none d-xl-none"></div>'),
        'xl': $('<div class="d-none d-xl-block d-sm-none d-md-none d-lg-none"></div>'),
    };
    viewport.use('custom', visibilityDivs);

    // Executes once whole document has been loaded
    $(document).ready(function () {
        if (viewport.is('xs')) {
            //console.log('xs');
            $('#filterDiv').addClass('fixed-bottom').removeClass('show');
        }

        // Executes in SM, MD and LG breakpoints
        if (viewport.is('sm')) {
            //console.log('sm');
            $('#filterDiv').addClass('fixed-bottom').removeClass('show');
        }

        // Executes in XS and SM breakpoints
        if (viewport.is('md')) {
            //console.log('md');
            $('#filterDiv').addClass('fixed-bottom').removeClass('show');
        }
        //console.log('Current breakpoint:', viewport.current());           
    });

    $(window).resize(
        viewport.changed(function () {
            // Executes only in XS breakpoint
            if (viewport.is('xs')) {
                //console.log('xs');
                $('#filterDiv').addClass('fixed-bottom').removeClass('show');
            }

            // Executes in SM, MD and LG breakpoints
            if (viewport.is('sm')) {
                //console.log('sm');
                $('#filterDiv').addClass('fixed-bottom').removeClass('show');
            }

            // Executes in XS and SM breakpoints
            if (viewport.is('md')) {
                //console.log('md');
                $('#filterDiv').addClass('fixed-bottom').removeClass('show');
            }

            if (viewport.is('lg')) {
                //console.log('lg');
                $('#filterDiv').removeClass('fixed-bottom').addClass('show');
            }

            if (viewport.is('xl')) {
                //console.log('xl');
                $('#filterDiv').removeClass('fixed-bottom').addClass('show');
            }
            //console.log('Current breakpoint:', viewport.current());
        })
    );
})(jQuery, document, window, ResponsiveBootstrapToolkit);

