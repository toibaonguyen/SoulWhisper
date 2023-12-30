import * as React from "react";

import { styled } from "@mui/system";
const Item = styled("div")(({ theme }) => ({
  backgroundColor: theme.palette.mode === "dark" ? "#262B32" : "#fff",
  padding: theme.spacing(1),
  textAlign: "center",
  borderRadius: 4,
}));

export default Item;
