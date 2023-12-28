jQuery(".form-valide").validate({
    rules: {
        "val-username": {
            required: !0,
            minlength: 3
        },

        "val-supplier-name": {
            required: !0,
        },
        "val-sub-contractor": {
            required: !0,
        },
        "val-party-code": {
            required: !0,
        },
        "val-party-name": {
            required: !0,
        },
        "val-purchase_product-code": {
            required: !0,
        },
        "val-purchase_product-name": {
            required: !0,
        },
        "val-sales_product-code": {
            required: !0,
        },
        "val-sales_product-name": {
            required: !0,
        },
        "val-unit-name": {
            required: !0,
        },
        "val-location": {
            required: !0,
        },
        "val-address": {
            required: !0,
        },
        "val-city": {
            required: !0,
        },
        "val-designation": {
            required: !0,
        },
        "val-contact-person": {
            required: !0,
        },
        "val-contact-1": {
            required: !0,
        },
        "val-contact-2": {
            required: !0,
        },
        "val-fax-num": {
            required: !0,
        },
        "val-cell-num": {
            required: !0,
        },
        "val-s_tax": {
            required: !0,
        },
        "val-vat_tin": {
            required: !0,
        },
        "val-cst_tin": {
            required: !0,
        },
        "val-pan": {
            required: !0,
        },
        "val-gst": {
            required: !0,
        },

        "val-email": {
            required: !0,
            email: !0
        },
        "val-password": {
            required: !0,
            minlength: 5
        },
        "val-confirm-password": {
            required: !0,
            equalTo: "#val-password"
        },
        "val-select2": {
            required: !0
        },
        "val-select2-multiple": {
            required: !0,
            minlength: 2
        },
        "val-suggestions": {
            required: !0,
            minlength: 5
        },
        "val-skill": {
            required: !0
        },
        "val-currency": {
            required: !0,
            currency: ["$", !0]
        },
        "val-website": {
            required: !0,
            url: !0
        },
        "val-phoneus": {
            required: !0,
            phoneUS: !0
        },
        "val-digits": {
            required: !0,
            digits: !0
        },
        "val-number": {
            required: !0,
            number: !0
        },
        "val-range": {
            required: !0,
            range: [1, 5]
        },
        "val-terms": {
            required: !0
        }
    },
    messages: {
        "val-username": {
            required: "Please enter a username",
            minlength: "Your username must consist of at least 3 characters"
        },
        "val-supplier-name": {
            required: "Please enter a supplier name"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-sub-contractor": {
            required: "Please enter a sub contractor name"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-party-code": {
            required: "Please enter a party code"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-party-name": {
            required: "Please enter a party name"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-purchase_product-code": {
            required: "Please enter a purchase product code"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-purchase_product-name": {
            required: "Please enter a purchase product name"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-sales_product-code": {
            required: "Please enter a sales product code"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-sales_product-name": {
            required: "Please enter a sales product name"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-unit-name": {
            required: "Please enter a unit name"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-address": {
            required: "Please enter a address"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-location": {
            required: "Please enter a location"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-city": {
            required: "Please enter a city"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-designation": {
            required: "Please enter a designation"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-contact-person": {
            required: "Please enter a contact person name"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-contact-1": {
            required: "Please enter a contact 1!"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-contact-2": {
            required: "Please enter a contact 2!"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-fax-num": {
            required: "Please enter a fax number"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-cell-num": {
            required: "Please enter a cell number"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-s_tax": {
            required: "Please enter a s tax number"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-vat_tin": {
            required: "Please enter a vat tin number"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-cst_tin": {
            required: "Please enter a cst tin number"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-pan": {
            required: "Please enter a pan number"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },
        "val-gst": {
            required: "Please enter a gst number"
            /*minlength: "Your username must consist of at least 3 characters"*/
        },

        "val-email": "Please enter a valid email address",
        "val-password": {
            required: "Please provide a password",
            minlength: "Your password must be at least 5 characters long"
        },
        "val-confirm-password": {
            required: "Please provide a password",
            minlength: "Your password must be at least 5 characters long",
            equalTo: "Please enter the same password as above"
        },
        "val-select2": "Please select a value!",
        "val-select2-multiple": "Please select at least 2 values!",
        "val-suggestions": "What can we do to become better?",
        "val-skill": "Please select a skill!",
        "val-currency": "Please enter a price!",
        "val-website": "Please enter your website!",
        "val-phoneus": "Please enter a US phone!",
        "val-digits": "Please enter only digits!",
        "val-number": "Please enter a number!",
        "val-range": "Please enter a number between 1 and 5!",
        "val-terms": "You must agree to the service terms!"
    },

    ignore: [],
    errorClass: "invalid-feedback animated fadeInUp",
    errorElement: "div",
    errorPlacement: function(e, a) {
        jQuery(a).parents(".form-group > div").append(e)
    },
    highlight: function(e) {
        jQuery(e).closest(".form-group").removeClass("is-invalid").addClass("is-invalid")
    },
    success: function(e) {
        jQuery(e).closest(".form-group").removeClass("is-invalid"), jQuery(e).remove()
    },
});


jQuery(".form-valide-with-icon").validate({
    rules: {
        "val-username": {
            required: !0,
            minlength: 3
        },
        "val-password": {
            required: !0,
            minlength: 5
        }
    },
    messages: {
        "val-username": {
            required: "Please enter a username",
            minlength: "Your username must consist of at least 3 characters"
        },
        "val-password": {
            required: "Please provide a password",
            minlength: "Your password must be at least 5 characters long"
        }
    },

    ignore: [],
    errorClass: "invalid-feedback animated fadeInUp",
    errorElement: "div",
    errorPlacement: function(e, a) {
        jQuery(a).parents(".form-group > div").append(e)
    },
    highlight: function(e) {
        jQuery(e).closest(".form-group").removeClass("is-invalid").addClass("is-invalid")
    },
    success: function(e) {
        jQuery(e).closest(".form-group").removeClass("is-invalid").addClass("is-valid")
    }




});