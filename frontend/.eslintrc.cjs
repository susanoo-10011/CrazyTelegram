module.exports = {
  root: true,
  env: {
    browser: true,
    es2020: true,
  },
  extends: [
    "eslint:recommended",
    "plugin:@typescript-eslint/recommended",
    "plugin:react-hooks/recommended",
    "plugin:prettier/recommended",
    "plugin:import/errors",
    "plugin:import/warnings",
    "plugin:import/typescript",
  ],
  ignorePatterns: ["dist", ".eslintrc.cjs"],
  parser: "@typescript-eslint/parser",
  plugins: ["react-refresh", "prettier", "import"],
  settings: {
    "import/resolver": {
      "alias": {
        "map": [
          ["@", "./src"],
          ["@app", "./src/app"],
          ["@pages", "./src/pages"],
          ["@widgets", "./src/widgets"],
          ["@features", "./src/features"],
          ["@entities", "./src/entities"],
          ["@shared", "./src/shared"]
        ],
        "extensions": [".ts", ".tsx", ".js", ".jsx", ".json"]
      }
    }
  },
  rules: {
    "no-restricted-imports": [
      "error",
      {
        "patterns": [
          "**/../*"
        ]
      }
    ],
    semi: ["error", "always"],
    "linebreak-style": ["off"],
    quotes: ["error", "double"],
    "react-refresh/only-export-components": [
      "warn",
      { allowConstantExport: true },
    ],
    "prettier/prettier": "error",
    "import/order": [
      "error",
      {
        groups: [
          ["builtin", "external"],
          "internal",
          ["parent", "sibling", "index"],
          "object",
        ],
        "newlines-between": "always",
        alphabetize: { order: "asc", caseInsensitive: true },
      },
    ],
  },
};
