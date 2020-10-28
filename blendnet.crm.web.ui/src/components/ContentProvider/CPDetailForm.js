import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import { FormControl } from '@material-ui/core';
import TextField from '@material-ui/core/TextField';
import Switch from '@material-ui/core/Switch';
import FormGroup from '@material-ui/core/FormGroup';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import { withStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';


const useStyles = makeStyles((theme) => ({
  root: {
    '& .MuiTextField-root': {
      margin: theme.spacing(1),
      width: '26ch',
    },
  },
  card: {
    minWidth: 200,
  },
  bullet: {
    display: 'inline-block',
    margin: '0 2px',
    transform: 'scale(0.8)',
  },
  title: {
    fontSize: 14,
  },
  pos: {
    marginBottom: 12,
  },

}));

const StatusSwitch = withStyles((theme) => ({
  root: {
    width: 42,
    height: 26,
    padding: 0,
    margin: theme.spacing(1),
  },
  switchBase: {
    padding: 1,
    '&$checked': {
      transform: 'translateX(16px)',
      color: theme.palette.common.white,
      '& + $track': {
        backgroundColor: '#52d869',
        opacity: 1,
        border: 'none',
      },
    },
    '&$focusVisible $thumb': {
      color: '#52d869',
      border: '6px solid #fff',
    },
  },
  thumb: {
    width: 24,
    height: 24,
  },
  track: {
    borderRadius: 26 / 2,
    border: `1px solid ${theme.palette.grey[400]}`,
    backgroundColor: theme.palette.grey[50],
    opacity: 1,
    transition: theme.transitions.create(['background-color', 'border']),
  },
  checked: {},
  focusVisible: {},
}))(({ classes, ...props }) => {
  return (
    <Switch
      focusVisibleClassName={classes.focusVisible}
      disableRipple
      classes={{
        root: classes.root,
        switchBase: classes.switchBase,
        thumb: classes.thumb,
        track: classes.track,
        checked: classes.checked,
      }}
      {...props}
    />
  );
});


export default function DetailForm() {
  const classes = useStyles();
  const [state, setState] = React.useState({
    status: true,
  });

  const handleChange = (event) => {
    setState({ ...state, [event.target.name]: event.target.checked });
  };


  return (
    <div>
      <h1>
          Content Provider Detail
      </h1>
      <Grid container spacing={3}>
        <Grid item xs={12} sm={4} lg={4}>
        <TextField
            id="standard-read-only-input"
            label="Content Provider Name"
            defaultValue="Mishtu Mobile Booth"
            variant="outlined"
            required/>
        </Grid>
        <Grid item xs={12} sm={4} lg={4}>
        <TextField
            id="standard-read-only-input"
            label="Contact"
            defaultValue="9665037918"
            variant="outlined"
            required/>
        </Grid>
        <Grid item xs={12} sm={4} lg={4}>
          <FormControlLabel
              control={<StatusSwitch checked={state.status} onChange={handleChange} name="status" />}
              label="Status"
          />
        </Grid>
        <Grid item xs={12} sm={12} lg={12}>
          Address
        </Grid>
        <Grid item  xs={12} sm={12} lg={12}>
          <TextField
            id="outlined-multiline-static"
            label="Street"
            fullWidth
            defaultValue="Ranka colony road"
            variant="outlined"
            required
          />
        </Grid>
        <Grid item  xs={12} sm={4} lg={4}>
          <TextField
            id="outlined-multiline-static"
            label="City"
            defaultValue="Benguluru"
            variant="outlined"
            required
          />
        </Grid>
        <Grid item  xs={12} sm={4} lg={4}>
          <TextField
            id="outlined-multiline-static"
            label="State"
            defaultValue="Karnataka"
            variant="outlined"
            required
          />
        </Grid>
        <Grid item  xs={12} sm={4} lg={4}>
          <TextField
            id="outlined-multiline-static"
            label="Pincode"
            defaultValue="560076"
            variant="outlined"
            required
          />
        </Grid>
        <Grid item xs={12} sm={4} lg={4}>
          <TextField
              id="standard-read-only-input"
              label="Activation Date"
              defaultValue="2020-10-28T08:05:36.789Z"
              variant="outlined"
              required/>
        </Grid>
        <Grid item xs={12} sm={4} lg={4}>
          <TextField
              id="standard-read-only-input"
              label="De-activation Date"
              defaultValue="2020-10-28T08:05:36.789Z"
              variant="outlined"
              required/>
        </Grid>
        <Grid item xs={0} sm={4} lg={4}>
        </Grid>
        
        <Grid item xs={12} sm={12} lg={12}>
          Content Admistrators
        </Grid>
        <Grid item xs={12} sm={3} lg={3}>
          <Card className={classes.card}>
            <CardContent>
              <Typography className={classes.title} color="textSecondary" gutterBottom>
                Admin 1
              </Typography>
              <Typography variant="h5" component="h2">
                Admin Name
              </Typography>
              <Typography className={classes.pos} color="textSecondary">
                Contact
              </Typography>
              <Typography variant="body2" component="p">
                Detail line 1
                <br />
                Details line 2
              </Typography>
            </CardContent>
            <CardActions>
              <Button size="small">More Info</Button>
            </CardActions>
          </Card>
          </Grid>
          <Grid item xs={12} sm={3} lg={3}>
          <Card className={classes.card}>
            <CardContent>
              <Typography className={classes.title} color="textSecondary" gutterBottom>
                Admin 2
              </Typography>
              <Typography variant="h5" component="h2">
                Admin Name
              </Typography>
              <Typography className={classes.pos} color="textSecondary">
                Contact
              </Typography>
              <Typography variant="body2" component="p">
                Detail line 1
                <br />
                Details line 2
              </Typography>
            </CardContent>
            <CardActions>
              <Button size="small">More Info</Button>
            </CardActions>
          </Card>
          </Grid>
      </Grid>
  </div>
  );
}
 