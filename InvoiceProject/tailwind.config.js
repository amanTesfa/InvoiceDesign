
module.exports = {
    content: [
        "./Views/**/*.cshtml",
        "./Views/**/*.html",
        "./wwwroot/**/*.js",
        "./src/**/*.{js,css,html}",
    ],
    plugins: [require('daisyui')],
    daisyui: {
        themes: [
            {
                forest: {
                    "primary": "#0b6623",
                    "primary-content": "#ffffff",
                    "secondary": "#2f9e44",
                    "secondary-content": "#ffffff",
                    "accent": "#0f9d58",
                    "accent-content": "#ffffff",
                    "neutral": "#1f2937",
                    "neutral-content": "#e6f4ea",
                    "base-100": "#f0fdf4",
                    "base-content": "#052e16",
                    "info": "#0ea5b8",
                    "info-content": "#ffffff",
                    "success": "#16a34a",
                    "success-content": "#ffffff",
                    "warning": "#f59e0b",
                    "warning-content": "#000000",
                    "error": "#dc2626",
                    "error-content": "#ffffff"
                }
            },
            "light",
            "dark"
        ],
        darkTheme: "dark",
    },
};
